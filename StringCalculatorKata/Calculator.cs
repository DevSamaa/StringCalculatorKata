using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {

        public int Add(string incomingString)
        {
            if (string.IsNullOrEmpty(incomingString))
            {
                return 0;
            }
            // var numbers = incomingString.Split(",");
            var numbers = incomingString.Split(',', '\n');
            return numbers.Sum(number => int.Parse(number));
            
        }
        
    }
}

