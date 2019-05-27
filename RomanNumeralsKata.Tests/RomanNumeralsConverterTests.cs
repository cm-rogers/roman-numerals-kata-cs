using FluentAssertions;
using Xunit;

namespace RomanNumeralsKata.Tests
{
    public class RomanNumeralsConverterTests
    {
        private readonly RomanNumeralsConverter _numeralsConverter;

        public RomanNumeralsConverterTests()
        {
            _numeralsConverter = new RomanNumeralsConverter();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2342)]
        [InlineData(-90872435)]
        public void ItReturnsAnEmptyStringForNumbersOfZeroOrLess(int decimalNumber)
        {
            _numeralsConverter.Convert(decimalNumber);

            _numeralsConverter.ToString().Should().Be("");
        }

        [Theory]
        [InlineData(3001)]
        [InlineData(6000)]
        [InlineData(9422)]
        [InlineData(23453)]
        [InlineData(2345253)]
        [InlineData(6003498)]
        [InlineData(7384902)]
        public void ItReturnsAnEmptyStringForValuesOverThreeThousand(int decimalNumber)
        {
            _numeralsConverter.Convert(decimalNumber);

            _numeralsConverter.ToString().Should().Be("");
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        public void ItReturnsTheCorrectSingularNumerals(
            int decimalNumber,
            string expectedRomanNumeral)
        {
            _numeralsConverter.Convert(decimalNumber);

            _numeralsConverter.ToString().Should().Be(expectedRomanNumeral);
        }

        [Theory]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        public void ItReturnsTheCorrectAmountOfTheNumeralIForTwoAndThree(
            int decimalNumber,
            string expectedRomanNumeral)
        {
            _numeralsConverter.Convert(decimalNumber);

            _numeralsConverter.ToString().Should().Be(expectedRomanNumeral);
        }

        [Theory]
        // ReSharper disable StringLiteralTypo
        [InlineData(6, "VI")]
        [InlineData(8, "VIII")]
        [InlineData(15, "XV")]
        [InlineData(16, "XVI")]
        [InlineData(20, "XX")]
        [InlineData(60, "LX")]
        [InlineData(65, "LXV")]
        [InlineData(66, "LXVI")]
        [InlineData(150, "CL")]
        [InlineData(160, "CLX")]
        [InlineData(165, "CLXV")]
        [InlineData(166, "CLXVI")]
        [InlineData(600, "DC")]
        [InlineData(650, "DCL")]
        [InlineData(660, "DCLX")]
        [InlineData(665, "DCLXV")]
        [InlineData(666, "DCLXVI")]
        [InlineData(1500, "MD")]
        [InlineData(1600, "MDC")]
        [InlineData(1650, "MDCL")]
        [InlineData(1660, "MDCLX")]
        [InlineData(1665, "MDCLXV")]
        [InlineData(1666, "MDCLXVI")]
        [InlineData(2050, "MML")]
        // ReSharper restore StringLiteralTypo  
        public void ItReturnsTheCorrectNumeralCompoundWhenTheNumeralOnTheRightOfThePreviousIsOfAHigherValue(
            int decimalNumber,
            string expectedRomanNumeral)
        {
            _numeralsConverter.Convert(decimalNumber);

            _numeralsConverter.ToString().Should().Be(expectedRomanNumeral);
        }

        [Theory]
        // ReSharper disable StringLiteralTypo
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(40, "XL")]
        [InlineData(49, "XLIX")]
        [InlineData(99, "XCIX")]
        // ReSharper restore StringLiteralTypo 
        public void ItReturnsCompoundSubtractionNumerals(
            int decimalNumber,
            string expectedRomanNumeral)
        {
            _numeralsConverter.Convert(decimalNumber);

            _numeralsConverter.ToString().Should().Be(expectedRomanNumeral);
        }

        [Theory]
        // ReSharper disable StringLiteralTypo
        [InlineData(41, "XLI")]
        [InlineData(42, "XLII")]
        [InlineData(45, "XLV")]
        [InlineData(2948, "MMCMXLVIII")]
        // ReSharper restore StringLiteralTypo
        public void ItReturnsCompoundSubtractionNumeralsWithAdditionNumerals(
            int decimalNumber,
            string expectedRomanNumeral)
        {
            _numeralsConverter.Convert(decimalNumber);

            _numeralsConverter.ToString().Should().Be(expectedRomanNumeral);
        }
    }
}
