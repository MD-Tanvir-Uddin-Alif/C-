using System;
using System.ComponentModel.DataAnnotations;

namespace TrackerApp.Models
{
    public class Goal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal TargetAmount { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public decimal CurrentAmount { get; set; } = 0m;

        public double PercentageComplete => TargetAmount == 0 ? 0 : (double)(CurrentAmount / TargetAmount) * 100;
    }
}
