namespace RomanNumeralsKata
{
    public class RomanNumeralsConverter
    {
        public string Convert(int decimalValue)
        {
            if (decimalValue == 1)
            {
                return "I";
            }

            if (decimalValue == 2)
            {
                return "II";
            }

            return "";
        }
    }
}
