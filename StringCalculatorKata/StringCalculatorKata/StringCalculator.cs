using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata
{
    class StringCalculator
    {
        IList<char> defaultDelimiters = new List<char> {',','\n'};
        public StringCalculator()
        {
        }

        internal decimal Add(string delimitedNumbers)
        {
            IList<char> delimiters = GetDelimiters(delimitedNumbers);
            if (HasCustomDelimiters(delimitedNumbers))
            {
                delimitedNumbers = delimitedNumbers.Substring(4);
            }

            if (string.IsNullOrWhiteSpace(delimitedNumbers))
            {
                return 0m;
            }

            var numberList = delimitedNumbers
                .Split(delimiters.ToArray())
                .Select(x => Decimal.Parse(x));

            var negativeNumbers = numberList.Where(number => number < 0);
            if (negativeNumbers.Any())
            {
                throw new ArgumentException(
                    String.Format(
                        "negatives not allowed: {0}", 
                        String.Join(",", negativeNumbers.OrderByDescending(number => number))
                    )
                );
            }

            return numberList.Sum();
        }

        private IList<char> GetDelimiters(string delimitedNumbers)
        {
            IList<char> delimiters;
            if (HasCustomDelimiters(delimitedNumbers))
            {
                delimiters = delimitedNumbers.Substring(2, 1).ToCharArray();
            }
            else
            {
                delimiters = defaultDelimiters;
            }
            return delimiters;
        }

        private static bool HasCustomDelimiters(string delimitedNumbers)
        {
            return delimitedNumbers.Length > 3 && delimitedNumbers.Substring(0, 2) == "//";
        }
    }
}
