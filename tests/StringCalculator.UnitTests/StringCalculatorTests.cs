using System;
using Xunit;

namespace StringCalculator.UnitTests
{
    public class StringCalculatorTests
    {
        StringCalculator sc = new StringCalculator();

        [Fact]
        public void Add_returns_0_for_empty_string()
        {
            var result = sc.Add(string.Empty);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public void Add_returns_input_in_case_of_one_argument(string input)
        {
            var result = sc.Add(input);

            Assert.Equal(input, result.ToString());
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,4", 7)]
        public void Add_returns_sum_in_case_of_two_arguments(string input, int expectedSum)
        {
            var result = sc.Add(input);

            Assert.Equal(expectedSum, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("5,6,7,8,9", 35)]
        public void Add_returns_sum_in_case_of_more_than_two_arguments(string input, int expectedSum)
        {
            var result = sc.Add(input);

            Assert.Equal(expectedSum, result);
        }
    }
}
