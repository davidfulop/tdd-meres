using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private int callCount;

        public int Add(string input)
        {
            callCount++;

            if (string.IsNullOrEmpty(input))
                return 0;

            var separators = GenerateSeparators(input);
            var cleanInput = RemoveCustomSeparatorFromInput(input);
            var numbers = ExtractNumbers(cleanInput, separators);
            ThrowForNegativeNumber(numbers);
            var filteredNumbers = FilterOutTooBigNumbers(numbers);
            return filteredNumbers.Aggregate((a, b) => a + b);
        }

        public int GetCalledCount()
        {
            return callCount++;
        }

        private static IEnumerable<int> FilterOutTooBigNumbers(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= 1000);
        }

        private static void ThrowForNegativeNumber(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(n => n < 0);
            if (negativeNumbers.Any())
                throw new System.ArgumentException(
                    $"Negative numbers aren't allowed. ({string.Join(", ", negativeNumbers)})");
        }

        private static IEnumerable<int> ExtractNumbers(string input, char[] separators)
        {
            return input.Split(separators).Select(s => int.Parse(s));
        }

        private static string RemoveCustomSeparatorFromInput(string input)
        {
            return ContainsCustomSeparator(input) ? input.Substring(4) : input;
        }

        private static char[] GenerateSeparators(string input)
        {
            var separators = new List<char> { ',', '\n' };
            if (ContainsCustomSeparator(input))
                separators.Add((char)input.Split(new[] { '\n' })[0].Substring(2, 1)[0]);
            return separators.ToArray();
        }

        private static bool ContainsCustomSeparator(string input)
        {
            return input.StartsWith("//");
        }
    }
}
