﻿namespace CollatzConjecture
{
    public class OneThreadSolver : CollatzConjectureSolver
    {
        public override double GetAverageIterations(ICollection<int> numbers)
        {
            long sum = 0;
            foreach (int num in numbers)
            {
                sum += GetIterationsCount(num);
            }
            return (double)sum / numbers.Count;
        }

        public override string ToString()
        {
            return "One thread";
        }
    }
}
