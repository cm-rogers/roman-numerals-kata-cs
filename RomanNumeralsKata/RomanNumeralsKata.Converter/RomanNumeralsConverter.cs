using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsKata
{
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
                        // @TODO: Remove this use of `while`
                        while (result.DecimalValue < decimalValue)
                        {
                            result.DecimalValue += numeral.DecimalValue;
                            result.NumeralValue += numeral.NumeralValue;
                        }

                        return result;
                    })
                .NumeralValue;
        }
    }
}
