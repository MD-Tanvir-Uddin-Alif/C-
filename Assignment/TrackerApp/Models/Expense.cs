using System;
using System.ComponentModel.DataAnnotations;

namespace TrackerApp.Models
{
    public enum ExpenseCategory { Food, Transport, Bills, Entertainment, Other, Custom }

    public class Expense
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be > 0")]
        public decimal Amount { get; set; }

        [Required, StringLength(150)]
        public string Description { get; set; }

        public ExpenseCategory Category { get; set; } = ExpenseCategory.Other;

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
