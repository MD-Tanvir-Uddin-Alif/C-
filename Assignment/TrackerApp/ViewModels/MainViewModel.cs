using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TrackerApp.Models;
using TrackerApp.Repositories;
using TrackerApp.Services;
using System.Linq;

namespace TrackerApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Repositories & service (in real app, inject via DI)
        private readonly InMemoryRepository<User> _userRepo = new();
        private readonly InMemoryRepository<Expense> _expenseRepo = new();
        private readonly InMemoryRepository<Goal> _goalRepo = new();
        private readonly InMemoryRepository<Habit> _habitRepo = new();
        private readonly TrackerService _service;

        public ObservableCollection<Expense> Expenses { get; set; } = new();
        public ObservableCollection<Habit> Habits { get; set; } = new();
        public ObservableCollection<Goal> Goals { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand AddExpenseCommand { get; set; }
        public RelayCommand AddHabitCommand { get; set; }
        public RelayCommand LogHabitCommand { get; set; }
        public RelayCommand AddGoalCommand { get; set; }

        // sample fields bound to UI
        public decimal NewExpenseAmount { get; set; }
        public string? NewExpenseDescription { get; set; }
        public ExpenseCategory NewExpenseCategory { get; set; } = ExpenseCategory.Other;

        public string? NewHabitName { get; set; }
        public Frequency NewHabitFrequency { get; set; } = Frequency.Daily;

        public string? NewGoalTitle { get; set; }
        public decimal NewGoalTarget { get; set; }
        public DateTime NewGoalDeadline { get; set; } = DateTime.Now.AddMonths(1);

        public Guid CurrentUserId { get; set; }

        public MainViewModel()
        {
            // add a demo user
            var user = new User { Username = "demo", Password = "password", Email = "demo@example.com" };
            _userRepo.Add(user);
            CurrentUserId = user.Id;

            _service = new TrackerService(_userRepo, _expenseRepo, _goalRepo, _habitRepo);

            // subscribe to notifications (UI or logger)
            NotificationService.OnNotify += NotificationService_OnNotify;

            AddExpenseCommand = new RelayCommand(_ => AddExpense());
            AddHabitCommand = new RelayCommand(_ => AddHabit());
            LogHabitCommand = new RelayCommand(h => LogHabit(h as Habit));
            AddGoalCommand = new RelayCommand(_ => AddGoal());

            // load initial collections
            RefreshCollections();
        }

        private void NotificationService_OnNotify(object? sender, Services.NotificationEventArgs args)
        {
            // In a real UI, you might show a popup. Here we write to console and could add to a messages collection.
            Console.WriteLine($"{args.Time}: {args.Title} - {args.Message}");
        }

        private void RefreshCollections()
        {
            Expenses.Clear();
            foreach (var e in _expenseRepo.GetAll().Cast<Expense>()) Expenses.Add(e);
            Habits.Clear();
            foreach (var h in _habitRepo.GetAll().Cast<Habit>()) Habits.Add(h);
            Goals.Clear();
            foreach (var g in _goalRepo.GetAll().Cast<Goal>()) Goals.Add(g);
        }

        public void AddExpense()
        {
            try
            {
                var exp = new Expense
                {
                    UserId = CurrentUserId,
                    Amount = NewExpenseAmount,
                    Description = NewExpenseDescription ?? "No desc",
                    Category = NewExpenseCategory,
                    Date = DateTime.Now
                };

                // Basic validation
                if (exp.Amount <= 0) throw new ArgumentException("Amount must be > 0");

                _service.AddExpense(exp);
                RefreshCollections();
                NewExpenseAmount = 0;
                NewExpenseDescription = string.Empty;
                OnPropertyChanged(nameof(NewExpenseAmount));
                OnPropertyChanged(nameof(NewExpenseDescription));
            }
            catch (Exception ex)
            {
                // Exception handling - update UI accordingly (messagebox/log)
                MessageBox.Show($"Error adding expense: {ex.Message}");
            }
        }

        public void AddHabit()
        {
            try
            {
                var habit = new Habit
                {
                    Name = NewHabitName ?? "Unnamed Habit",
                    Frequency = NewHabitFrequency
                };
                if (string.IsNullOrWhiteSpace(habit.Name)) throw new ArgumentException("Habit name required");
                _service.AddHabit(habit);
                RefreshCollections();
                NewHabitName = string.Empty;
                OnPropertyChanged(nameof(NewHabitName));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding habit: {ex.Message}");
            }
        }

        public void LogHabit(Habit? habit)
        {
            if (habit == null) return;
            try
            {
                _service.LogHabitCompletion(habit.Id, DateTime.Now);
                RefreshCollections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging habit: {ex.Message}");
            }
        }

        public void AddGoal()
        {
            try
            {
                var goal = new Goal
                {
                    Title = NewGoalTitle ?? "Unnamed Goal",
                    TargetAmount = NewGoalTarget,
                    Deadline = NewGoalDeadline
                };
                _service.AddGoal(goal);
                RefreshCollections();
                NewGoalTitle = string.Empty;
                NewGoalTarget = 0;
                OnPropertyChanged(nameof(NewGoalTitle));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding goal: {ex.Message}");
            }
        }

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}