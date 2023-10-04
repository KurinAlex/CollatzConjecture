namespace CollatzConjecture
{
    public abstract class CollatzConjectureSolver
    {
        public abstract double GetAverageIterations(ICollection<int> numbers);

        public override abstract string ToString();

        protected static int GetIterationsCount(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Input number must be positive integer");
            }

            int iterations = 0;
            long n = number;

            while (n > 1)
            {
                if (long.IsEvenInteger(n))
                {
                    n /= 2;
                }
                else
                {
                    checked
                    {
                        n = 3 * n + 1;
                    }
                }
                iterations++;
            }

            return iterations;
        }
    }
}
