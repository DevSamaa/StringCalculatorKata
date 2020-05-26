using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {

        public int Add(string incomingString)
        {
            // var isNumber = int.TryParse(incomingString, out int result);
            // return isNumber ? result : 0;
            
            // var number1 = Convert.ToInt32(incomingString[0]);
            // var number2 = Convert.ToInt32(incomingString[2]);
            // return number1 + number2;
            
            // var listOfNumbers =incomingString.Where(c => c >= 0);
            // listOfNumbers.Sum()
            // return listOfNumbers;
            
            // int result = 0;
            // foreach (var c in incomingString)
            // {
            //     if (c >= 0 && c !=',' )
            //     {
            //         result += int.Parse(c.ToString());
            //     }
            // }
            //
            // return result;

            // var numbers = incomingString.Split(",");
            // var result = 0;
            // foreach (var number in numbers)
            // {
            //     var isNumber = int.TryParse(number, out int resultOfParse);
            //     if (!isNumber)
            //     {
            //         break;
            //     }
            //     result += resultOfParse;
            // }
            // return result;
            
            if (string.IsNullOrEmpty(incomingString))
            {
                return 0;
            }
            var numbers = incomingString.Split(",");
            return numbers.Sum(number => int.Parse(number));
            
            // int sum = 0;
            // foreach(char c in incomingString)
            // {
            //     if(c == 44)
            //     {
            //         continue;
            //     }
	           //
            //     sum += c - 48;
            // }
            //
            // return sum;

        }
        
    }
}

