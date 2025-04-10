namespace CollatzConjecture;

public abstract class MultithreadingSolver(int threadsCount) : CollatzConjectureSolver
{
	public override double GetAverageIterations(ICollection<int> numbers)
	{
		Initialize(numbers);

		var containers = new List<Container>(threadsCount);
		var threads = new List<Thread>(threadsCount);
		for (var i = 0; i < threadsCount; i++)
		{
			var container = new Container();
			var thread = new Thread(Run);

			containers.Add(container);
			threads.Add(thread);

			thread.Start(container);
		}

		foreach (var thread in threads)
		{
			thread.Join();
		}

		var sum = containers.Sum(container => container.Sum);
		return (double)sum / numbers.Count;
	}

	private void Run(object? o)
	{
		if (o is not Container container)
		{
			throw new ArgumentException($"Argument has wrong type. Must be {typeof(Container)}");
		}

		while (TryGetNext(out var num))
		{
			var iterations = GetIterationsCount(num);
			container.Sum += iterations;
		}
	}

	protected abstract void Initialize(ICollection<int> numbers);

	protected abstract bool TryGetNext(out int num);

	private class Container
	{
		public long Sum { get; set; }
	}
}