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
    }
}
