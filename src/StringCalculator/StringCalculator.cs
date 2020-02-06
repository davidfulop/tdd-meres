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
            return numbers.Aggregate((a,b) => a+b);
        }
    }
}
