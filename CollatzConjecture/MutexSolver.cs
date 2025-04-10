namespace CollatzConjecture;

public class MutexSolver(int threadsCount) : MultithreadingSolver(threadsCount)
{
	private Queue<int> _numbersQueue = new();
	private readonly Mutex _mutex = new();

	public override string Name => "Multithreading (mutex)";

	protected override void Initialize(ICollection<int> numbers)
	{
		_numbersQueue = new Queue<int>(numbers);
	}

	protected override bool TryGetNext(out int num)
	{
		_mutex.WaitOne();
		try
		{
			if (!_numbersQueue.TryDequeue(out num))
			{
				return false;
			}
		}
		finally
		{
			_mutex.ReleaseMutex();
		}

		return true;
	}
}