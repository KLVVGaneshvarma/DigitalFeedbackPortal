using DigitalFeedbackPortal.Models;

namespace DigitalFeedbackPortal.Utilities
{
    public static class FeedbackValidator
    {
        public static bool IsValid(FeedbackEntry entry)
        {
            return !string.IsNullOrWhiteSpace(entry.EmployeeName)
                && !string.IsNullOrWhiteSpace(entry.Message)
                && Enum.IsDefined(typeof(Category), entry.Category);
        }
    }
}