using System;
using System.Collections.Generic;
using Xunit;

namespace CurrencyToText.Library.UnitTests
{
    public class MoneyToWordsConverterUnitTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CanConvertValidMoneyStringToEnglishTextCorrectly(string inputMoney, string outputText)
        {
            Assert.Equal(outputText, MoneyToWordsConverter.ToEnglishWords(inputMoney));
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("$1000.01")]
        public void WhenInvalidInputMoneyStringThenThrowsCorrectException(string inputMoney)
        {
            var exceptionReceived =
                Assert.Throws<ArgumentOutOfRangeException>(() => MoneyToWordsConverter.ToEnglishWords(inputMoney));

            Assert.StartsWith($"Input value is out of range.", exceptionReceived.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        [InlineData("$$10")]
        [InlineData("1.000,00")]
        public void WhenInvalidInputStringThenThrowsCorrectException(string inputMoney)
        {
            var exceptionReceived =
                Assert.Throws<ArgumentException>(() => MoneyToWordsConverter.ToEnglishWords(inputMoney));

            Assert.Equal($"Unable to parse input value.", exceptionReceived.Message);
        }

        [Fact]
        public void WhenCentsIsMoreThan2DecimalPlaceThanThrowArgumentException()
        {
            var exceptionReceived =
                Assert.Throws<ArgumentException>(() => MoneyToWordsConverter.ToEnglishWords("0.001"));

            Assert.Equal("Input contains more than 2 decimal places", exceptionReceived.Message);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {"0", "zero dollars"},
                new object[] {"0.01", "zero dollars and one cent"},
                new object[] {"$0.10", "zero dollars and ten cents"},
                new object[] {"0.4", "zero dollars and forty cents"},
                new object[] {"0.04", "zero dollars and four cents"},
                new object[] {"1", "one dollar"},
                new object[] {"55", "fifty five dollars"},
                new object[] {"100", "one hundred dollars"},
                new object[] {"101", "one hundred and one dollars"},
                new object[] {"110", "one hundred and ten dollars"},
                new object[] {"$1,000", "one thousand dollars"},
            };
    }
}
