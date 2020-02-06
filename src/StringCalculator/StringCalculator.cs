using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;
            var numbers = input.Split(new[] {','}).Select(s => int.Parse(s)).ToArray();
            if (numbers.Length == 1)
                return numbers[0];
            return numbers[0] + numbers[1];
        }
    }
}
