namespace CollatzConjecture
{
    public class LockSolver : MultithreadingSolver
    {
        private Queue<int> numbersQueue = new();
        private readonly object lockObj = new();

        public LockSolver(int threadsCount) : base(threadsCount)
        {
        }

        public override string ToString()
        {
            return "Multithreading (lock)";
        }

        protected override void Initialize(ICollection<int> numbers)
        {
            numbersQueue = new Queue<int>(numbers);
        }

        protected override bool TryGetNext(out int num)
        {
            lock (lockObj)
            {
                if (!numbersQueue.TryDequeue(out num))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
