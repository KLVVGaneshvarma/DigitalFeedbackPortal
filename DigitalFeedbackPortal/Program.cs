using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Utilities;
using System;

namespace DigitalFeedbackPortal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Employee emp = new Employee(1, null, "IT");
                Console.WriteLine("Employee name length: " + emp.Name.Length); // causes exception
            }
            catch (NullReferenceException ex)
            {
                Logger.LogError("Null reference error: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.LogError("Unauthorized access: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogError("General error: " + ex.Message);
            }

            Console.WriteLine("Program completed with error logging.");
        }
    }
}
