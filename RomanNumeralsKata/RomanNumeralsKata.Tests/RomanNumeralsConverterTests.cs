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

        [Fact]
        public void ItReturnsIWhenTheDecimalIsOne()
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(1).Should().Be("I");
        }

        [Fact]
        public void ItReturnsIiWhenTheDecimalIsTwo()
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(2).Should().Be("II");
        }

        [Fact]
        public void ItReturnsIiiWhenTheDecimalIsThree()
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(3).Should().Be("III");
        }

        [Fact]
        public void ItReturnsIvWhenTheDecimalIsFour()
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(4).Should().Be("IV");
        }
    }
}
