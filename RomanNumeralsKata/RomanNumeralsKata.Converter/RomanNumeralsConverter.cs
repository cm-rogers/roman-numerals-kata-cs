using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsKata
{
    internal static class IntExtensions
    {
        public static int AddRepeat(this int i, int value, int count)
        {
            return i + value * count;
        }
    }

    internal static class StringExtensions
    {
        public static string AddRepeat(this string s, string value, int count)
        {
            return s + string.Join("", ArrayList.Repeat(value, count).ToArray());
        }
    }

    internal class RomanNumeral
    {
        public int DecimalValue = 0;
        public string NumeralValue = "";
    }

    public class RomanNumeralsConverter
    {
        private readonly IEnumerable<RomanNumeral> _numerals = new List<RomanNumeral>
        {
            new RomanNumeral{DecimalValue = 1000, NumeralValue = "M"},
            new RomanNumeral{DecimalValue = 900, NumeralValue = "CM"},
            new RomanNumeral{DecimalValue = 500, NumeralValue = "D"},
            new RomanNumeral{DecimalValue = 400, NumeralValue = "CD"},
            new RomanNumeral{DecimalValue = 100, NumeralValue = "C"},
            new RomanNumeral{DecimalValue = 90, NumeralValue = "XC"},
            new RomanNumeral{DecimalValue = 50, NumeralValue = "L"},
            new RomanNumeral{DecimalValue = 40, NumeralValue = "XL"},
            new RomanNumeral{DecimalValue = 10, NumeralValue = "X"},
            new RomanNumeral{DecimalValue = 9, NumeralValue = "IX"},
            new RomanNumeral{DecimalValue = 5, NumeralValue = "V"},
            new RomanNumeral{DecimalValue = 4, NumeralValue = "IV"},
            new RomanNumeral{DecimalValue = 1, NumeralValue = "I"},
        };

        public string Convert(int decimalValue)
        {
            if (decimalValue > 3000)
            {
                throw new ArgumentOutOfRangeException(nameof(decimalValue), "Values must be less than 3000");
            }

            return _numerals.Aggregate(
                new RomanNumeral(),
                (result, numeral) =>
                {
                    var differenceBetweenResultAndTargetDecimal = decimalValue - result.DecimalValue;

                    if (differenceBetweenResultAndTargetDecimal == 0)
                    {
                        return result;
                    }

                    var repeatCount = differenceBetweenResultAndTargetDecimal / numeral.DecimalValue;

                    if (repeatCount < 1)
                    {
                        return result;
                    }

                    result.NumeralValue = result.NumeralValue.AddRepeat(numeral.NumeralValue, repeatCount);
                    result.DecimalValue = result.DecimalValue.AddRepeat(numeral.DecimalValue, repeatCount);

                    return result;
                }
            ).NumeralValue;
        }
    }
}
