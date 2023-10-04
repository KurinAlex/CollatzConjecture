namespace CollatzConjecture
{
    public class InterlockedSolver : MultithreadingSolver
    {
        private IList<int> numbersList = new List<int>();
        private int index;

        public InterlockedSolver(int threadsCount) : base(threadsCount)
        {
        }

        public override string ToString()
        {
            return "Multithreading (interlocked)";
        }

        protected override void Initialize(ICollection<int> numbers)
        {
            numbersList = numbers.ToList();
            index = -1;
        }

        protected override bool TryGetNext(out int num)
        {
            int currentIndex = Interlocked.Increment(ref index);
            if (currentIndex < numbersList.Count)
            {
                num = numbersList[currentIndex];
                return true;
            }
            num = 0;
            return false;
        }
    }
}
