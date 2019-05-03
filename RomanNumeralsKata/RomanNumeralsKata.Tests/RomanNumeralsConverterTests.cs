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
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        public void ItReturnsTheCorrectCompoundNumeral(int decimalValue, string expectedNumeral)
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(decimalValue).Should().Be(expectedNumeral);
        }

        [Fact]
        public void ItReturnsIvWhenTheDecimalIsFour()
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(4).Should().Be("IV");
        }
    }
}
