namespace CollatzConjecture
{
    public abstract class CollatzConjectureSolver
    {
        public abstract double GetAverageIterations(ICollection<int> numbers);

        public override abstract string ToString();

        protected static int GetIterationsCount(int number)
        {
            int iterations = 0;
            long n = number;

            while (n > 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = 3 * n + 1;
                }
                iterations++;
            }

            return iterations;
        }
    }
}
