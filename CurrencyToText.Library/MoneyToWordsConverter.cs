using System;
using System.Globalization;
using static System.Decimal;

namespace CurrencyToText.Library
{
    public static class MoneyToWordsConverter
    {
        public static string ToEnglishWords(decimal monetaryValue)
        {
            if (monetaryValue < 0m || monetaryValue > 1000m)
                throw new ArgumentOutOfRangeException(nameof(monetaryValue), "Input value is out of range.");

            if (monetaryValue == 0)
                return "zero dollars";

            var dollarAmount = Floor(monetaryValue);
            var centsAmount = (monetaryValue - dollarAmount) * 100;

            var hasMoreThan2DecimalPlace = centsAmount - Floor(centsAmount) > 0;
            if (hasMoreThan2DecimalPlace)
                throw new ArgumentException("Input contains more than 2 decimal places");

            var dollarTextSuffix = dollarAmount == 1 ? "dollar" : "dollars";
            var centTextSuffix = centsAmount == 1 ? "cent" : "cents";

            return centsAmount == 0
                ? $"{NumberToWords.ConvertWholeNumberToWords((uint)dollarAmount)} {dollarTextSuffix}"
                : $"{NumberToWords.ConvertWholeNumberToWords((uint)dollarAmount)} {dollarTextSuffix} and {NumberToWords.ConvertWholeNumberToWords((uint)centsAmount)} {centTextSuffix}";
        }

        public static string ToEnglishWords(string monetaryValue)
        {
            var canParse = TryParse(monetaryValue, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-NZ"),
                out decimal money);

            if (!canParse)
                throw new ArgumentException("Unable to parse input value.");

            return ToEnglishWords(money);
        }
    }
}
