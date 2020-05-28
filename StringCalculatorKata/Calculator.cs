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
            string[] delimiter;
            string numberString;
            
            if (startsWithSlash)
            {
                var startOfDelimiter = incomingString.IndexOf('/')+2; //2
                var endOfDelimiter = incomingString.IndexOf('\n'); //7
                var lengthOfDelimiter = endOfDelimiter - startOfDelimiter; //5
                
                if (lengthOfDelimiter >1)
                {
                    delimiter =  new []{incomingString.Substring(startOfDelimiter+1, lengthOfDelimiter-2)};
                }
                else
                {
                    delimiter =  new []{incomingString.Substring(startOfDelimiter, lengthOfDelimiter)};
 
                }
                
                numberString = incomingString.Substring(incomingString.IndexOf('\n')+1);
            }
            else
            {
                delimiter = new[] {"," , "\n"};
                numberString = incomingString;
            }
            return  SplitAndSum(delimiter, numberString);
        }

        private int SplitAndSum(string[] delimiter, string incomingString)
        {
            var splitItems = incomingString.Split(delimiter, System.StringSplitOptions.RemoveEmptyEntries).ToList();
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
// delimiter starts at index[2], \n starts at index[3], 3-2 =1 length of delimiter ==1
//    Add("//;\n       1;2") > Returns 3

// delimiter starts at index[2], \n starts at index[5], 5-2=3, length of delimiter ==3
//incomingstring.substing(index[2],{lengthOfDelimiter})
//    Add("//***\n     1***2***3") > Returns 6 

