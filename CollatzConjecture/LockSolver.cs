namespace CollatzConjecture;

public class LockSolver(int threadsCount) : MultithreadingSolver(threadsCount)
{
	private Queue<int> _numbersQueue = new();
	private readonly object _lockObj = new();

	public override string Name => "Multithreading (lock)";

	protected override void Initialize(ICollection<int> numbers)
	{
		_numbersQueue = new Queue<int>(numbers);
	}

	protected override bool TryGetNext(out int num)
	{
		lock (_lockObj)
		{
			return _numbersQueue.TryDequeue(out num);
		}
	}
}