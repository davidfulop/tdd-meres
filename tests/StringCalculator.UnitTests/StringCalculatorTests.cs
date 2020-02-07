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

        [Fact]
        public void Add_allows_newline_as_separator()
        {
            var expectedSum = 6;

            var result = sc.Add("1\n2,3");

            Assert.Equal(expectedSum, result);
        }

        [Fact]
        public void Add_allows_custom_separator()
        {
            var input = "//;\n1\n2,3;4";
            var expectedSum = 10;

            var result = sc.Add(input);

            Assert.Equal(expectedSum, result);
        }

        [Fact]
        public void Add_throws_when_there_is_a_negative_number_in_input()
        {
            var negativeNumber = -3;
            var input = $"1,2,{negativeNumber},4";

            var exception = Assert.Throws<ArgumentException>(() => sc.Add(input));
            Assert.True(exception.Message == 
                $"Negative numbers aren't allowed. ({negativeNumber})");
        }

        [Theory]
        [InlineData("-3,-4", "-3, -4")]
        [InlineData("3,-5\n-10", "-5, -10")]
        public void Add_throws_with_all_negative_numbers_in_message(string input, string expectedNumbers)
        {
            var exception = Assert.Throws<ArgumentException>(() => sc.Add(input));
            Assert.True(exception.Message ==
                $"Negative numbers aren't allowed. ({expectedNumbers})");
        }
    }
}
