using System;
using System.Collections.Generic;
using Xunit;

namespace CurrencyToText.Library.UnitTests
{
    public class NumberToWordsUnitTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CanConvertNumbersUpToOneMillionToWordsCorrectly(uint inputNumber, string outputText)
        {
            Assert.Equal(outputText, NumberToWords.ConvertWholeNumberToWords(inputNumber));
        }

        [Fact]
        public void CanReceiveExceptionCorrectlyWhenNumberIsOutOfRange()
        {
            var exceptionReceived =
                Assert.Throws<ArgumentException>(() =>
                    NumberToWords.ConvertWholeNumberToWords(1000000)); // Million is not supported;

            Assert.Equal("Input 1000000 is not supported for conversion", exceptionReceived.Message);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {0, "zero"},
                new object[] {1, "one"},
                new object[] {2, "two"},
                new object[] {3, "three"},
                new object[] {4, "four"},
                new object[] {5, "five"},
                new object[] {6, "six"},
                new object[] {7, "seven"},
                new object[] {8, "eight"},
                new object[] {9, "nine"},
                new object[] {10, "ten"},
                new object[] {11, "eleven"},
                new object[] {12, "twelve"},
                new object[] {13, "thirteen"},
                new object[] {14, "fourteen"},
                new object[] {15, "fifteen"},
                new object[] {16, "sixteen"},
                new object[] {17, "seventeen"},
                new object[] {18, "eighteen"},
                new object[] {19, "nineteen"},
                new object[] {20, "twenty"},
                new object[] {30, "thirty"},
                new object[] {40, "forty"},
                new object[] {50, "fifty"},
                new object[] {60, "sixty"},
                new object[] {70, "seventy"},
                new object[] {80, "eighty"},
                new object[] {90, "ninety"},
                new object[] {55, "fifty five"},
                new object[] {100, "one hundred"},
                new object[] {101, "one hundred and one"},
                new object[] {110, "one hundred and ten"},
                new object[] {1000, "one thousand"},
                new object[] {1111, "one thousand, and one hundred and eleven"},
                new object[] {10000, "ten thousand"},
                new object[] {10100, "ten thousand, and one hundred"},
                new object[] {100000, "one hundred thousand"},
                new object[] {101015, "one hundred and one thousand, and fifteen"},
                new object[] {999999, "nine hundred and ninety nine thousand, and nine hundred and ninety nine"},
                new object[] {99999, "ninety nine thousand, and nine hundred and ninety nine"},
                new object[] {9999, "nine thousand, and nine hundred and ninety nine"},
                new object[] {999, "nine hundred and ninety nine"},
                new object[] {99, "ninety nine"},
            };
    }
}
