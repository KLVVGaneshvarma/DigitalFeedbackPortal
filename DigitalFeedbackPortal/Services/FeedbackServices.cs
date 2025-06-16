using System.Text.Json;
using System.Text.Json.Serialization;
using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Utilities;

namespace DigitalFeedbackPortal.Services
{
    public static class FeedbackService
    {
        private static readonly string FilePath = "feedback.json";

        public static async Task SubmitFeedbackAsync(FeedbackEntry entry)
        {
            if (!FeedbackValidator.IsValid(entry))
                throw new ArgumentException("Invalid Feedback Entry.");

            // Configure JSON options to support enum values as strings
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            List<FeedbackEntry> entries = new();
            if (File.Exists(FilePath))
            {
                string json = await File.ReadAllTextAsync(FilePath);
                if (!string.IsNullOrWhiteSpace(json))
                    entries = JsonSerializer.Deserialize<List<FeedbackEntry>>(json, options) ?? new List<FeedbackEntry>();
            }

            entries.Add(entry);

            string updatedJson = JsonSerializer.Serialize(entries, options);
            await File.WriteAllTextAsync(FilePath, updatedJson);
        }
    }
}
