using System.Collections.Concurrent;

namespace CollatzConjecture
{
    public class ConcurrentQueueSolver : MultithreadingSolver
    {
        private ConcurrentQueue<int> numbersQueue = new();

        public ConcurrentQueueSolver(int threadsCount) : base(threadsCount)
        {
        }

        public override string ToString()
        {
            return "Multithreading (concurrent queue)";
        }

        protected override void Initialize(ICollection<int> numbers)
        {
            numbersQueue = new ConcurrentQueue<int>(numbers);
        }

        protected override bool TryGetNext(out int num)
        {
            return numbersQueue.TryDequeue(out num);
        }
    }
}
