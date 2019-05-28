using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace RomanNumeralsKata.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class ConverterTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10987)]
        [InlineData(int.MinValue)]
        public void ItReturnsNullWhenTheDecimalIsUnderOne(int decimalValue)
        {
            var output = RomanNumerals.Convert(decimalValue);

            output.Should().Be(null);
        }

        [Theory]
        [InlineData(3001)]
        [InlineData(4945)]
        [InlineData(214748)]
        [InlineData(int.MaxValue)]
        public void ItReturnsNullWhenTheDecimalIsOverThreeThousand(int decimalValue)
        {
            var output = RomanNumerals.Convert(decimalValue);

            output.Should().Be(null);
        }

        [Theory]
        [InlineData(-0.1, null)]
        [InlineData(0.1, null)]
        [InlineData(5.5, "VI")]
        [InlineData(40.4, "XL")]
        [InlineData(3000.1, "MMM")]
        [InlineData(3000.9, null)]
        public void ItRoundsDecimalValuesToTheNearestInteger(
            int decimalValue,
            string expectedValue)
        {
            var output = RomanNumerals.Convert(decimalValue);

            output.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        public void ItReturnsTheNumeralIForTheCorrectDecimalAmount(
            int decimalValue,
            string expectedNumeral)
        {
            var output = RomanNumerals.Convert(decimalValue);

            output.Should().Be(expectedNumeral);
        }

        [Theory]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(11, "XI")]
        [InlineData(22, "XXII")]
        [InlineData(51, "LI")]
        [InlineData(55, "LV")]
        [InlineData(66, "LXVI")]
        [InlineData(88, "LXXXVIII")]
        [InlineData(116, "CXVI")]
        [InlineData(133, "CXXXIII")]
        [InlineData(277, "CCLXXVII")]
        [InlineData(363, "CCCLXIII")]
        [InlineData(555, "DLV")]
        [InlineData(637, "DCXXXVII")]
        [InlineData(3000, "MMM")]
        public void ItReturnsTheCorrectCompoundNumeralForTheDecimalAmount(
            int decimalValue,
            string expectedNumeral)
        {
            var output = RomanNumerals.Convert(decimalValue);

            output.Should().Be(expectedNumeral);
        }

        [Theory]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(14, "XIV")]
        [InlineData(19, "XIX")]
        [InlineData(24, "XXIV")]
        [InlineData(29, "XXIX")]
        [InlineData(41, "XLI")]
        [InlineData(44, "XLIV")]
        [InlineData(49, "XLIX")]
        [InlineData(90, "XC")]
        [InlineData(94, "XCIV")]
        [InlineData(99, "XCIX")]
        [InlineData(494, "CDXCIV")]
        [InlineData(444, "CDXLIV")]
        [InlineData(911, "CMXI")]
        [InlineData(999, "CMXCIX")]
        [InlineData(2999, "MMCMXCIX")]
        public void ItReturnsTheCorrectCompoundSubtractionNumeralForTheDecimalAmount(
            int decimalValue,
            string expectedNumeral)
        {
            var output = RomanNumerals.Convert(decimalValue);

            output.Should().Be(expectedNumeral);
        }
    }
}
