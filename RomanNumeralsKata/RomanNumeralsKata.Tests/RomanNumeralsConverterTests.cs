using FluentAssertions;
using Xunit;

namespace RomanNumeralsKata.Tests
{
    public class RomanNumeralsConverterTests
    {
        [Fact]
        public void ItReturnsAnEmptyStringWhenTheDecimalIsZero()
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(0).Should().Be("");
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        public void ItReturnsTheCorrectSingularNumeral(int decimalValue, string expectedNumeral)
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(decimalValue).Should().Be(expectedNumeral);
        }

        [Theory]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(11, "XI")]
        [InlineData(18, "XVIII")]
        [InlineData(21, "XXI")]
        [InlineData(28, "XXVIII")]
        [InlineData(31, "XXXI")]
        [InlineData(38, "XXXVIII")]
        public void ItReturnsTheCorrectCompoundNumeral(int decimalValue, string expectedNumeral)
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(decimalValue).Should().Be(expectedNumeral);
        }

        [Theory]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(14, "XIV")]
        [InlineData(19, "XIX")]
        [InlineData(24, "XXIV")]
        [InlineData(29, "XXIX")]
        [InlineData(34, "XXXIV")]
        [InlineData(39, "XXXIX")]
        public void ItReturnsTheCorrectCompoundSubtractionNumeral(int decimalValue, string expectedNumeral)
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(decimalValue).Should().Be(expectedNumeral);
        }
    }
}
