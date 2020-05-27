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

            var startsWithSlash = incomingString.StartsWith("//");
            if (startsWithSlash)
            {
                // take the delimiter after the // and store it in a var
                var newDelimiter = incomingString[2];
               
                //create a substring of everything after the (first) /n
                var newString = incomingString.Substring(incomingString.IndexOf('\n')+1);
                var numbers = newString.Split(newDelimiter);
                
                //TODO change this, it's currently not DRY
                return numbers.Sum(number => int.Parse(number));

            }
            
            var numbers2 = incomingString.Split(',', '\n');
           
            //figure out if any number is smaller than 0, if so throw error with message that contains the numbers
            return numbers2.Sum(number => int.Parse(number));
            
        }
        
    }
}


