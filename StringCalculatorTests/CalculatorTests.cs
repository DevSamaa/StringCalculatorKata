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
        
        [Fact]
        public void TakeEmptyStringAndReturnInt()
        {
            var result = _calculator.Add("");
            Assert.Equal(0, result);
        }
        
        [Theory]
        [InlineData("1",1)]
        [InlineData("3",3)]
        public void TakeStringNumberAndReturnInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }

        [Theory]
        [InlineData("1,2",3)]
        [InlineData("3,5",8)]
        public void TakeStringWithTwoNumbersAndReturnOneInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
        [Theory]
        [InlineData("1,2,3",6)]
        [InlineData("3,5,3,9",20)]
        public void TakeStringWithMultipleNumbersAndReturnOneInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
        
       
        [Theory]
        [InlineData("1,2\n3",6)]
        [InlineData("3\n5\n3,9",20)]
        public void TakeStringWithLineBreaksAndReturnOneInt(string incomingString, int expectedOutcome)
        {
            var result = _calculator.Add(incomingString);
            Assert.Equal(expectedOutcome,result);
        }
    }
}


