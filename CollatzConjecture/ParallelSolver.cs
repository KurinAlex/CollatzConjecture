namespace CollatzConjecture
{
    public class ParallelSolver : CollatzConjectureSolver
    {
        public override double GetAverageIterations(ICollection<int> numbers)
        {
            long sum = 0;
            Parallel.ForEach(numbers, n =>
            {
                Interlocked.Add(ref sum, GetIterationsCount(n));
            });
            return (double)sum / numbers.Count;
        }

        public override string ToString()
        {
            return "Parallel";
        }
    }
}
