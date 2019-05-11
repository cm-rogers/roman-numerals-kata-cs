using System;
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
        public void ItThrowsForNumbersOverThreeThousand()
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            var exception = Record.Exception(() => romanNumeralsConverter.Convert(3001));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            exception.Message.Should().Contain("Values must be less than 3000");
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
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
        [InlineData(55, "LV")]
        [InlineData(66, "LXVI")]
        [InlineData(77, "LXXVII")]
        [InlineData(88, "LXXXVIII")]
        [InlineData(166, "CLXVI")]
        [InlineData(222, "CCXXII")]
        [InlineData(368, "CCCLXVIII")]
        [InlineData(555, "DLV")]
        [InlineData(873, "DCCCLXXIII")]
        [InlineData(1867, "MDCCCLXVII")]
        [InlineData(2638, "MMDCXXXVIII")]
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
        [InlineData(40, "XL")]
        [InlineData(41, "XLI")]
        [InlineData(44, "XLIV")]
        [InlineData(48, "XLVIII")]
        [InlineData(49, "XLIX")]
        [InlineData(99, "XCIX")]
        [InlineData(444, "CDXLIV")]
        [InlineData(624, "DCXXIV")]
        [InlineData(900, "CM")]
        [InlineData(994, "CMXCIV")]
        public void ItReturnsTheCorrectCompoundSubtractionNumeral(int decimalValue, string expectedNumeral)
        {
            var romanNumeralsConverter = new RomanNumeralsConverter();

            romanNumeralsConverter.Convert(decimalValue).Should().Be(expectedNumeral);
        }
    }
}
