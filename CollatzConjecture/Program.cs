using System.Diagnostics;

namespace CollatzConjecture;

internal static class Program
{
	private static int EnterPositiveInt(string name)
	{
		int result;
		string? input;
		do
		{
			Console.Write($"Enter {name}: ");
			input = Console.ReadLine();
		} while (!int.TryParse(input, out result) || result < 1);

		return result;
	}

	private static void Main()
	{
		var numbersCount = EnterPositiveInt("numbers count");
		var threadsCount = EnterPositiveInt("threads count");

		var numbers = new List<int>(numbersCount);
		for (var num = 1; num <= numbersCount; num++)
		{
			numbers.Add(num);
		}

		CollatzConjectureSolver[] solvers =
		{
			new OneThreadSolver(),
			new ParallelSolver(),
			new LockSolver(threadsCount),
			new ConcurrentQueueSolver(threadsCount),
			new InterlockedSolver(threadsCount),
			new MutexSolver(threadsCount)
		};

		var results = new List<double>(solvers.Length);

		try
		{
			var timer = new Stopwatch();
			foreach (var solver in solvers)
			{
				timer.Restart();
				var result = solver.GetAverageIterations(numbers);
				timer.Stop();

				Console.WriteLine();
				Console.WriteLine($"{solver.Name}:");
				Console.WriteLine($"- Elapsed: {timer.Elapsed.TotalSeconds} s");
				Console.WriteLine($"- Result: {result}");

				results.Add(result);
			}

			var resultsEqual = results.TrueForAll(r => Math.Abs(r - results[0]) < 1e-5);

			Console.WriteLine();
			Console.Write("All results are equal: ");

			Console.ForegroundColor = resultsEqual ? ConsoleColor.Green : ConsoleColor.Red;
			Console.WriteLine(resultsEqual);
			Console.ResetColor();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
		}
	}
}