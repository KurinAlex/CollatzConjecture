namespace CollatzConjecture;

public class InterlockedSolver(int threadsCount) : MultithreadingSolver(threadsCount)
{
	private IList<int> _numbersList = new List<int>();
	private int _index;

	public override string Name => "Multithreading (interlocked)";

	protected override void Initialize(ICollection<int> numbers)
	{
		_numbersList = numbers.ToList();
		_index = -1;
	}

	protected override bool TryGetNext(out int num)
	{
		var currentIndex = Interlocked.Increment(ref _index);
		if (currentIndex < _numbersList.Count)
		{
			num = _numbersList[currentIndex];
			return true;
		}

		num = 0;
		return false;
	}
}