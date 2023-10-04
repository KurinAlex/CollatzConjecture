namespace CollatzConjecture
{
    public abstract class MultithreadingSolver : CollatzConjectureSolver
    {
        private readonly int threadsCount;

        protected MultithreadingSolver(int threadsCount)
        {
            this.threadsCount = threadsCount;
        }

        public override double GetAverageIterations(ICollection<int> numbers)
        {
            Initialize(numbers);

            var containers = new List<Container>(threadsCount);
            var threads = new List<Thread>(threadsCount);
            for (int i = 0; i < threadsCount; i++)
            {
                var container = new Container();
                var thread = new Thread(Run);

                containers.Add(container);
                threads.Add(thread);

                thread.Start(container);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            long sum = 0;
            foreach (Container container in containers)
            {
                sum += container.Sum;
            }

            return (double)sum / numbers.Count;
        }

        public abstract override string ToString();

        private void Run(object? o)
        {
            if (o is not Container container)
            {
                throw new ArgumentException($"Argument has wrong type. Must be {typeof(Container)}");
            }

            while (TryGetNext(out int num))
            {
                int iterations = GetIterationsCount(num);
                container.Sum += iterations;
            }
        }

        protected abstract void Initialize(ICollection<int> numbers);

        protected abstract bool TryGetNext(out int num);

        class Container
        {
            public long Sum
            {
                get;
                set;
            }
        }
    }
}
