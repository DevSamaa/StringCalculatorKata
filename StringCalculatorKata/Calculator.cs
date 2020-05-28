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
            string numberString;
            
            if (startsWithSlash)
            {
                // take the delimiter after the // and store it in a var
                delimiter = new[] {incomingString[2]};
               
                //create a substring of everything after the (first) /n
                numberString = incomingString.Substring(incomingString.IndexOf('\n')+1);
            }
            else
            {
                delimiter = new[] {',' , '\n'};
                numberString = incomingString;
            }
            return  SplitAndSum(delimiter, numberString);
        }

        private int SplitAndSum(char[] delimiter, string incomingString)
        {
            var splitItems = incomingString.Split(delimiter).ToList();
            var numbers = splitItems.Select(int.Parse).ToList();
            
            var negativeNumbers = numbers.Where(number => number < 0).ToList();
            if (negativeNumbers.Any())
            {
                var joinedNumbers = string.Join(", ", negativeNumbers);
                throw new Exception($"Negatives not allowed: {joinedNumbers}");
            }

            var numbersSmallerThan1000 = numbers.Where(number => number < 1000);
            return numbersSmallerThan1000.Sum();
        }
    }
}

//Maybe we should do a little bit more teaching. Maybe walk Samaa through some of the methods (String Methods) relevant for the next step.
