namespace CollatzConjecture;

public class ParallelSolver : CollatzConjectureSolver
{
	public override string Name => "Parallel";

	public override double GetAverageIterations(ICollection<int> numbers)
	{
		var sum = 0L;
		Parallel.ForEach(numbers, n => { Interlocked.Add(ref sum, GetIterationsCount(n)); });
		return (double)sum / numbers.Count;
	}
}