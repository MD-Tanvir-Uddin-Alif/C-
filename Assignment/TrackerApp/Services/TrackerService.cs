using System;
using System.Linq;
using TrackerApp.Models;
using TrackerApp.Repositories;
using System.Collections.Generic;

namespace TrackerApp.Services
{
    public class TrackerService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Expense> _expenseRepo;
        private readonly IRepository<Goal> _goalRepo;
        private readonly IRepository<Habit> _habitRepo;

        // Some simple business rules / thresholds
        private const decimal GoalNearCompletionThreshold = 0.9m; // 90%

        public TrackerService(IRepository<User> userRepo,
                              IRepository<Expense> expenseRepo,
                              IRepository<Goal> goalRepo,
                              IRepository<Habit> habitRepo)
        {
            _userRepo = userRepo;
            _expenseRepo = expenseRepo;
            _goalRepo = goalRepo;
            _habitRepo = habitRepo;
        }

        // Add expense with validation & exception handling
        public void AddExpense(Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            // example of using DataAnnotations programmatically could be added; simpler: quick checks
            if (expense.Amount <= 0) throw new ArgumentException("Amount must be positive");

            _expenseRepo.Add(expense);

            // After adding, check if this affects any goal's progress
            var affectedGoals = _goalRepo.GetAll().Where(g => g.Id != Guid.Empty).ToList(); // placeholder

            // Example: apply simple logic — add part of expense to goal? (in real app, user transfers money)
            foreach (var goal in affectedGoals)
            {
                if (goal.PercentageComplete >= (double)GoalNearCompletionThreshold)
                {
                    NotificationService.Notify("Goal Nearly Complete", $"Goal '{goal.Title}' at {goal.PercentageComplete:F1}%");
                }
            }
        }

        public IEnumerable<Expense> GetUserExpenses(Guid userId, DateTime? from = null, DateTime? to = null, ExpenseCategory? category = null)
        {
            var q = _expenseRepo.GetAll().Where(e => ((Expense)e).UserId == userId).Cast<Expense>();
            if (from.HasValue) q = q.Where(x => x.Date >= from.Value);
            if (to.HasValue) q = q.Where(x => x.Date <= to.Value);
            if (category.HasValue) q = q.Where(x => x.Category == category.Value);
            return q.OrderByDescending(x => x.Date).ToList();
        }

        public void AddGoal(Goal goal)
        {
            if (goal == null) throw new ArgumentNullException(nameof(goal));
            if (goal.Deadline <= DateTime.Now) throw new ArgumentException("Deadline must be in the future");
            _goalRepo.Add(goal);
        }

        public void AddHabit(Habit habit)
        {
            if (habit == null) throw new ArgumentNullException(nameof(habit));
            _habitRepo.Add(habit);
        }

        public void LogHabitCompletion(Guid habitId, DateTime date)
        {
            var habit = _habitRepo.Get(habitId);
            if (habit == null) throw new KeyNotFoundException("Habit not found");
            habit.CompletionDates.Add(date);
            _habitRepo.Update(habit);

            // Example delegate/notification use:
            NotificationService.Notify("Habit Logged", $"Logged '{habit.Name}' for {date:d}. Current streak: {habit.Streak}");
        }

        // Example LINQ analytics: monthly spend grouped by category
        public IEnumerable<dynamic> GetMonthlySpendByCategory(Guid userId, int year, int month)
        {
            var items = _expenseRepo.GetAll().Cast<Expense>().Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month == month);
            var summary = items.GroupBy(e => e.Category)
                               .Select(g => new { Category = g.Key, Total = g.Sum(x => x.Amount) })
                               .OrderByDescending(x => x.Total);
            return summary;
        }
    }
}
