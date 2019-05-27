using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsKata
{
    public class RomanNumeral
    {
        public int DecimalValue { get; set; }
        public string NumeralValue { get; set; }
    }

    public class RomanNumeralsConverter
    {
        private string _romanNumeralsResult = "";

        private static readonly List<RomanNumeral> RomanNumerals = new List<RomanNumeral>
        {
            new RomanNumeral{DecimalValue = 1, NumeralValue = "I"},
            new RomanNumeral{DecimalValue = 5, NumeralValue = "V"},
            new RomanNumeral{DecimalValue = 10, NumeralValue = "X"},
            new RomanNumeral{DecimalValue = 50, NumeralValue = "L"},
            new RomanNumeral{DecimalValue = 100, NumeralValue = "C"},
            new RomanNumeral{DecimalValue = 500, NumeralValue = "D"},
            new RomanNumeral{DecimalValue = 1000, NumeralValue = "M"},
        };

        public void Convert(int decimalInputNumber)
        {
            if (decimalInputNumber < 1 || decimalInputNumber > 3000)
            {
                return;
            }

            BuildRomanNumeralString(decimalInputNumber);
        }

        public override string ToString()
        {
            return _romanNumeralsResult;
        }

        private void BuildRomanNumeralString(int decimalInputNumber)
        {
            foreach (var romanNumeral in RomanNumerals.AsEnumerable().Reverse())
            {
                if (decimalInputNumber < 1)
                {
                    return;
                }

                if (decimalInputNumber == romanNumeral.DecimalValue)
                {
                    _romanNumeralsResult += romanNumeral.NumeralValue;

                    return;
                }

                decimalInputNumber = AppendNumeralUntilDecimalValueIsLessThanNumeral(
                    decimalInputNumber,
                    romanNumeral);

                decimalInputNumber = AddCompoundNumeralSubtractions(
                    decimalInputNumber,
                    romanNumeral);
            }
        }

        private int AddCompoundNumeralSubtractions(
            int decimalInputNumber,
            RomanNumeral rightNumeral)
        {
            foreach (var leftNumeral in RomanNumerals.AsEnumerable().Reverse())
            {
                var compoundSubtraction = rightNumeral.DecimalValue - leftNumeral.DecimalValue;

                if (compoundSubtraction == 0)
                {
                    continue;
                }

                var higherNumeralIsDoubleThisNumeral = rightNumeral.DecimalValue / 2 == leftNumeral.DecimalValue;

                if (higherNumeralIsDoubleThisNumeral)
                {
                    continue;
                }

                var decimalDivideByCompoundSubtraction = decimalInputNumber / compoundSubtraction;

                if (decimalDivideByCompoundSubtraction != 1)
                {
                    continue;
                }

                _romanNumeralsResult += leftNumeral.NumeralValue;
                _romanNumeralsResult += rightNumeral.NumeralValue;

                decimalInputNumber -= compoundSubtraction;
            }

            return decimalInputNumber;
        }

        private int AppendNumeralUntilDecimalValueIsLessThanNumeral(
            int decimalInputNumber,
            RomanNumeral romanNumeral)
        {
            while (decimalInputNumber >= romanNumeral.DecimalValue
                   && decimalInputNumber - romanNumeral.DecimalValue >= 0)
            {
                _romanNumeralsResult += romanNumeral.NumeralValue;
                decimalInputNumber -= romanNumeral.DecimalValue;
            }

            return decimalInputNumber;
        }
    }
}
