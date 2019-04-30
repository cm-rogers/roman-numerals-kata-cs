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
            return i += ArrayList.Repeat(value, count).Cast<int>().Sum();
        }
    }

    internal static class StringExtensions
    {
        public static string AddRepeat(this string s, string value, int count)
        {
            var valueArray = new string[count];
            Array.Fill(valueArray, value, 0, count);
            
            return s + string.Join("", valueArray);
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
            new RomanNumeral{DecimalValue = 1, NumeralValue = "I"},
        };

        public string Convert(int decimalValue)
        {
            return _numerals
                .Aggregate(
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
                    })
                .NumeralValue;
        }
    }
}
