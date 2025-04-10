namespace CollatzConjecture;

public class OneThreadSolver : CollatzConjectureSolver
{
	public override string Name => "One thread";

	public override double GetAverageIterations(ICollection<int> numbers)
	{
		var sum = numbers.Sum(GetIterationsCount);
		return (double)sum / numbers.Count;
	}
}