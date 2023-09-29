namespace CollatzConjecture
{
    public class MutexSolver : MultithreadingSolver
    {
        private Queue<int> numbersQueue = new();
        private readonly Mutex mutex = new();

        public MutexSolver(int threadsCount) : base(threadsCount)
        {
        }

        public override string ToString()
        {
            return "Multithreading (mutex)";
        }

        protected override void Initialize(ICollection<int> numbers)
        {
            numbersQueue = new Queue<int>(numbers);
        }

        protected override bool GetNext(out int num)
        {
            mutex.WaitOne();
            try
            {
                if (!numbersQueue.TryDequeue(out num))
                {
                    return false;
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
            return true;
        }
    }
}
