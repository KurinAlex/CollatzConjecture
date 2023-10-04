using System.Diagnostics;

namespace CollatzConjecture
{
    internal static class Program
    {
        static int EnterPositiveInt(string name)
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

        static void Main()
        {
            int numbersCount = EnterPositiveInt("numbers count");
            int threadsCount = EnterPositiveInt("threads count");

            var numbers = new List<int>(numbersCount);
            for (int num = 1; num <= numbersCount; num++)
            {
                numbers.Add(num);
            }

            CollatzConjectureSolver[] solvers = {
                new OneThreadSolver(),
                new ParallelSolver(),
                new LockSolver(threadsCount),
                new ConcurrentQueueSolver(threadsCount),
                new InterlockedSolver(threadsCount),
                new MutexSolver(threadsCount),
            };

            var results = new List<double>(solvers.Length);

            try
            {
                var timer = new Stopwatch();
                foreach (CollatzConjectureSolver solver in solvers)
                {
                    timer.Restart();
                    double result = solver.GetAverageIterations(numbers);
                    timer.Stop();

                    Console.WriteLine();
                    Console.WriteLine($"{solver}:");
                    Console.WriteLine($"- Elapsed: {timer.Elapsed.TotalSeconds} s");
                    Console.WriteLine($"- Result: {result}");

                    results.Add(result);
                }

                bool resultsEqual = results.TrueForAll(r => r == results[0]);

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
}
