using System;

namespace TrackerApp.Services
{
    // Delegate-based notification service (conceptual)
    public static class NotificationService
    {
        // Delegate for notifications
        public delegate void NotificationHandler(object sender, NotificationEventArgs args);

        // Event exposed for subscribers (UI or logger)
        public static event NotificationHandler OnNotify;

        public static void Notify(string title, string message)
        {
            try
            {
                OnNotify?.Invoke(null, new NotificationEventArgs { Title = title, Message = message, Time = DateTime.Now });
            }
            catch (Exception ex)
            {
                // Ensure delegates don't crash app — exception handling around delegate invocation
                Console.WriteLine($"Notification error: {ex.Message}");
            }
        }
    }

    public class NotificationEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
