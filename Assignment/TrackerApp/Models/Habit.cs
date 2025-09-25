using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TrackerApp.Models
{
    public enum Frequency { Daily, Weekly }

    public class Habit
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(80)]
        public string Name { get; set; }

        public Frequency Frequency { get; set; } = Frequency.Daily;

        // Simple log of dates when habit was completed
        public List<DateTime> CompletionDates { get; set; } = new List<DateTime>();

        public int Streak
        {
            get
            {
                // compute current consecutive daily/weekly streak (simple approach)
                if (CompletionDates == null || CompletionDates.Count == 0) return 0;
                CompletionDates.Sort();
                int streak = 1;
                for (int i = CompletionDates.Count - 1; i > 0; i--)
                {
                    var diff = (CompletionDates[i].Date - CompletionDates[i - 1].Date).Days;
                    if (Frequency == Frequency.Daily)
                    {
                        if (diff == 1) streak++; else break;
                    }
                    else // weekly
                    {
                        if (diff <= 7) streak++; else break;
                    }
                }
                return streak;
            }
        }
    }
}
