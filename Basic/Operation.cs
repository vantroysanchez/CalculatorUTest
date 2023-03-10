using System.Reflection.Metadata.Ecma335;

namespace Basic
{
    public class Operation
    {
        List<int> numbers = new();

        public int Add(int number1, int number2) => number1 + number2;

        public bool Even(int number) => number % 2 == 0;

        public double AddDecimals(double number1, double number2) => number1 + number2;

        public List<int> OddNumbers(int startNumber, int endNumber)
        {
            numbers.Clear();

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % 2 != 0)
                {
                    numbers.Add(i);
                }
            }
            return numbers;
        }
    }
}