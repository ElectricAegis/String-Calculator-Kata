using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata
{
    class StringCalculator
    {
        IList<char> supportedSeparators;
        public StringCalculator(IList<char> supportedSeparators)
        {
            this.supportedSeparators = supportedSeparators;
        }

        internal decimal Add(string commaSeparatedNumbers)
        {
            if (string.IsNullOrWhiteSpace(commaSeparatedNumbers))
            {
                return 0m;
            }
            var numberList = commaSeparatedNumbers
                .Split(supportedSeparators.ToArray())
                .Select(x => Decimal.Parse(x));
            return numberList.Sum();
        }
    }
}
