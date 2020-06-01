using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var startsWithSlash = input.StartsWith("//");
            string[] delimiter;
            string numberString;
            if (startsWithSlash)
            {
                var startOfDelimiter = input.IndexOf('/')+2; //2
                var endOfDelimiter = input.IndexOf('\n'); //7
                var lengthOfDelimiter = endOfDelimiter - startOfDelimiter; //5
                
                // delimiter is more than one character
                if (lengthOfDelimiter >1)
                {
                    var countOfBracket = input.Count(character => character == '[');
                    var insideBrackets = input.Substring(startOfDelimiter + 1, lengthOfDelimiter - 2);
                    // insideBrackets turns this: "//[***]\n1***2***3"   into "//[***]\n1"
                    if (countOfBracket == 1)
                    {
                        //  example:    "//[***]\n1***2***3"        delimiter: ***
                        delimiter =  new []{insideBrackets};
                    }
                    else
                    {
                        //  example:    "//[*][%]\n1*2%3"        delimiters: * , %
                        var listOfTempDelimiters = new[] {"[", "]"};
                        delimiter =insideBrackets.Split(listOfTempDelimiters, StringSplitOptions.RemoveEmptyEntries);
                    }
                }
                //it only goes here if the delimiter is 1 character
                else
                {
                    //example:       "//;\n1;2"           delimiter = ;
                    delimiter =  new []{input.Substring(startOfDelimiter, lengthOfDelimiter)};
                }
                
                numberString = input.Substring(input.IndexOf('\n')+1);
            }
            
            // if the incoming string doesn't start with slash
            else
            {
                delimiter = new[] {"," , "\n"};
                numberString = input;
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


