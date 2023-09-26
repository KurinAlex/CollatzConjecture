namespace CollatzConjecture
{
    public class OneThreadSolver : CollatzConjectureSolver
    {
        public override string ToString()
        {
            return "One thread";
        }

        public override double GetAverageIterations(ICollection<int> numbers)
        {
            long sum = 0;
            foreach (int num in numbers)
            {
                sum += GetIterationsCount(num);
            }
            return (double)sum / numbers.Count;
        }
    }
}
