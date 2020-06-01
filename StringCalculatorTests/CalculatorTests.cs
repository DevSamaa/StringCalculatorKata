using System;
using StringCalculatorKata;
using Xunit;


namespace StringCalculatorTests
{
    public class CalculatorShould
    {
        private Calculator _calculator;
        public CalculatorShould()
        {
            _calculator = new Calculator();
        }
        
        //Step 1
        [Fact]
        public void TakeEmptyStringAndReturnInt()
        {
            var result = _calculator.Add("");
            Assert.Equal(0, result);
        }
        
        //Step 2
        [Theory]
        [InlineData("1",1)]
        [InlineData("3",3)]
        public void TakeStringNumberAndReturnInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
        // Step 3
        [Theory]
        [InlineData("1,2",3)]
        [InlineData("3,5",8)]
        public void TakeStringWithTwoNumbersAndReturnOneInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
        //Step 4
        [Theory]
        [InlineData("1,2,3",6)]
        [InlineData("3,5,3,9",20)]
        public void TakeStringWithMultipleNumbersAndReturnOneInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
        // Step 5
        [Theory]
        [InlineData("1,2\n3",6)]
        [InlineData("3\n5\n3,9",20)]
        public void TakeStringWithLineBreaksAndReturnOneInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
        // Step 6
        [Fact]
        public void TakeStringWithNewDelimiterAndReturnInt()
        {
            var result = _calculator.Add("//;\n1;2");
            Assert.Equal(3, result);
        } 
        
        // Step 7
        [Fact]
        public void TakeStringWithNegativeNumberAndThrowError()
        {
            var ex = Assert.Throws<Exception>(() => _calculator.Add("-1,2,-3"));
            Assert.Equal("Negatives not allowed: -1, -3",ex.Message);
        } 
        
        
        // Step 8
        [Theory]
        [InlineData("1000,1001,2",2)]
        [InlineData("1000,999,2",1001)]
        public void IgnoreNumbersBiggerThan999(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
        //Step 9
        [Theory]
        [InlineData("//[***]\n1***2***3",6)]
        [InlineData("//[*****]\n1*****2*****3",6)]
        public void TakeMultiCharacterDelimiters(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
        //Step 10
        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//[*][%][!]\n1*2%3!4",10)]
        public void TakeMultipleDelimiters(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome, result);
        }
        
        //Step 11
        [Theory]
        [InlineData("//[***][#][%]\n1***2#3%4", 10)]
        public void TakeMultipleDelimitersWithDifferntLenghts(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome, result);
        }
        
        //Step 12
        [Theory]
        [InlineData("//[*1*][%]\n1*1*2%3",6)]
        [InlineData("//[*5**][%]\n1*5**2%3",6)]
        [InlineData("//[!9!!][*5**]\n1!9!!2*5**3",6)]
        public void TakeMultipleDelimitersWithNumbers(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome, result);
        }
    }
}


