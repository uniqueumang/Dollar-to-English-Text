using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CurrencyToText.Library.UnitTests")]

namespace CurrencyToText.Library
{
    internal static class NumberToWords
    {
        private static readonly string[] OnesMap =
        {
            string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven",
            "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        private static readonly string[] TensMap =
        {
            string.Empty, "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        /// <summary>
        /// In order to support million, billion and etc, add to this key value pair like this {1000000,"million"}. 
        /// Ensure previous period exists. For example if adding billion place-group, support for million exists. 
        /// </summary>
        private static readonly Dictionary<uint, string> PlaceGroupSuffix =
            new Dictionary<uint, string> {{1000, "thousand"}};

        internal static string ConvertWholeNumberToWords(uint number)
        {
            if (number == 0) return "zero";

            var placeGroupInDescendingOrder = PlaceGroupSuffix.OrderByDescending(t => t.Key).ToArray();

            //In international numbering system we group by hundreds. For example one thousand thousand to express one million is not correct.
            //Following ensures we never express it incorrectly.

            if ((number / placeGroupInDescendingOrder.First().Key) >= 1000)
            {
                throw new ArgumentException($"Input {number} is not supported for conversion");
            }

            var words = new StringBuilder();
            var remainder = number;

            foreach (var (positionValue, suffix) in placeGroupInDescendingOrder)
            {
                if (remainder != 0 && remainder >= positionValue)
                {
                    var quotient = remainder / positionValue;

                    remainder %= positionValue;
                    words.Append($"{ConvertToDigit(quotient)} {suffix}, ");
                }
            }

            // Convert last 3 digits to word
            if (remainder != 0)
            {
                var convertToDigit = ConvertToDigit(remainder);
                words.Append(words.Length != 0 ? $"and {convertToDigit}" : convertToDigit);
            }

            return words.ToString().Trim(' ', ',');
        }

        private static string ConvertToDigit(uint n)
        {
            string wordsBuilder = string.Empty;

            if (n >= 100)
            {
                var quotient = n / 100;
                n %= 100;
                wordsBuilder = $"{OnesMap[quotient]} hundred" + (n != 0 ? " and " : string.Empty);
            }

            // split n if it is more than 19
            if (n > 19)
            {
                wordsBuilder += $"{TensMap[n / 10]} ";
                n %= 10;
            }

            wordsBuilder += $"{OnesMap[n]}";

            return wordsBuilder;
        }
    }
}
