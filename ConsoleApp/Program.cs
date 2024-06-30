using lock_vs_readerwriteslimlock;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lockSlim = new ReaderWriterLockSlimDemo();
            lockSlim.TaskRunner();
        }

    }
}
