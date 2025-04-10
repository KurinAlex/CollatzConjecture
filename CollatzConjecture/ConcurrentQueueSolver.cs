using System.Collections.Concurrent;

namespace CollatzConjecture;

public class ConcurrentQueueSolver(int threadsCount) : MultithreadingSolver(threadsCount)
{
	private ConcurrentQueue<int> _numbersQueue = new();

	public override string Name => "Multithreading (concurrent queue)";

	protected override void Initialize(ICollection<int> numbers)
	{
		_numbersQueue = new ConcurrentQueue<int>(numbers);
	}

	protected override bool TryGetNext(out int num)
	{
		return _numbersQueue.TryDequeue(out num);
	}
}