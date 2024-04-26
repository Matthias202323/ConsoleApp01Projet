using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    internal class Validation
    {
        /// <summary>
        /// Validates that the provided string is a valid date in the DD/MM/YYYY format.
        /// </summary>
        /// <param name="dateStr">The date string to validate.</param>
        /// <returns>True if the date is valid and in the specified format, otherwise false.</returns>
        public static bool IsValidDate(string dateStr)
        {
            bool didParsedData = false;

            try
            {
                DateTime parsedDate;
                didParsedData = DateTime.TryParseExact(dateStr, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate);
            }
            catch (Exception ex)
            {
                Logger.Write($"[InputValidator] - {ex.Message}");
            }

            return didParsedData;
        }

        /// <summary>
        /// Checks if any of the provided strings are null or empty.
        /// </summary>
        /// <param name="inputs">Strings to check.</param>
        /// <returns>True if any string is null or empty, otherwise false.</returns>
        public static bool AnyNullOrEmpty(params string[] inputs)
        {
            bool isNullOrEmpty = false;
            try
            {
                isNullOrEmpty = inputs.Any(string.IsNullOrEmpty) || inputs.Any(input => input == "exit");
            }
            catch (Exception ex)
            {
                Logger.Write($"[InputValidator] - {ex.Message}");
            }

            return isNullOrEmpty;
        }

        /// <summary>
        /// Checks if any of the provided strings contain digits.
        /// </summary>
        /// <returns>True if any of the provided strings contain any digits, otherwise false.</returns>
        public static bool ContainsDigits(params string[] inputs)
        {
            bool doesContainDigit = false;

            try
            {
                doesContainDigit = inputs.Any(input => input.Any(char.IsDigit));
            }
            catch (Exception ex)
            {
                Logger.Write($"[InputValidator] - {ex.Message}");
            }

            return doesContainDigit;
        }
    }
}
