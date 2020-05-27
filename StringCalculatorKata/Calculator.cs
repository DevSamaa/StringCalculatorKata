using System;
using System.Collections.Generic;
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

            var startsWithSlash = incomingString.StartsWith("//");
            char[] delimiter;
            if (startsWithSlash)
            {
                // take the delimiter after the // and store it in a var
                delimiter = new[] {incomingString[2]};
               
                //create a substring of everything after the (first) /n
                var newString = incomingString.Substring(incomingString.IndexOf('\n')+1);
                return SplitAndSum(delimiter, newString);
            } 
            
            delimiter = new[] {',' , '\n'};
            return  SplitAndSum(delimiter, incomingString);
        }

        private int SplitAndSum(char[] delimiter, string incomingString)
        {
            var splitItems = incomingString.Split(delimiter).ToList();
            var numbers = splitItems.Select(int.Parse);
            
            if (numbers.Any(number => number<0))
            {
               throw new Exception($"Negatives not allowed:{number}");
            }
           
            return numbers.Sum();
        }
    }
}


