using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralsKata
{
    internal class RomanNumeral
    {
        public int DecimalValue;
        public string NumeralValue;
    }

    internal static class StringExtensions
    {
        public static string Repeat(this string s, int n)
            => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
    }

    public class RomanNumerals
    {
        private static readonly IEnumerable<RomanNumeral> Numerals = new List<RomanNumeral>
        {
            new RomanNumeral {DecimalValue = 1000, NumeralValue = "M"},
            new RomanNumeral {DecimalValue = 900, NumeralValue = "CM"},
            new RomanNumeral {DecimalValue = 500, NumeralValue = "D"},
            new RomanNumeral {DecimalValue = 400, NumeralValue = "CD"},
            new RomanNumeral {DecimalValue = 100, NumeralValue = "C"},
            new RomanNumeral {DecimalValue = 90, NumeralValue = "XC"},
            new RomanNumeral {DecimalValue = 50, NumeralValue = "L"},
            new RomanNumeral {DecimalValue = 40, NumeralValue = "XL"},
            new RomanNumeral {DecimalValue = 10, NumeralValue = "X"},
            new RomanNumeral {DecimalValue = 9, NumeralValue = "IX"},
            new RomanNumeral {DecimalValue = 5, NumeralValue = "V"},
            new RomanNumeral {DecimalValue = 4, NumeralValue = "IV"},
            new RomanNumeral {DecimalValue = 1, NumeralValue = "I"},
        };

        public static string Convert(int decimalValue)
        {
            var numeralValue = "";

            if (decimalValue > 3000)
            {
                return null;
            }

            foreach (var numeral in Numerals)
            {
                var numeralRepeatCount = decimalValue / numeral.DecimalValue;

                if (numeralRepeatCount <= 0)
                {
                    continue;
                }

                numeralValue += numeral.NumeralValue.Repeat(numeralRepeatCount);
                decimalValue -= numeral.DecimalValue * numeralRepeatCount;
            }

            return numeralValue.Any() ? numeralValue : null;
        }
    }
}