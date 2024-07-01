namespace lock_vs_readerwriteslimlock
{
    public class ReaderWriterLockSlimDemo
    {
        public static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private Dictionary<string, string> cache = new Dictionary<string, string>();
        public static object _locker = new object();

        public Dictionary<string, string> Cache
        {
            get
            {
                try
                {
                    //_lock.EnterReadLock();
                    lock (_lock)
                    {
                        return cache;
                    }
                }
                finally
                {
                    //_lock.ExitReadLock();
                }
            }
        }

        public ReaderWriterLockSlimDemo()
        {
            cache.Add("key1", "1");
            cache.Add("key2", "2");
            cache.Add("key3", "3");
            cache.Add("key4", "4");
            cache.Add("key5", "5");
        }

        public void RenewCache()
        {
            try
            {
                //_lock.EnterWriteLock();
                lock (_lock)
                {
                    cache = new Dictionary<string, string>();
                    cache.Add("key1", "1");
                    cache.Add("key2", "2");
                    cache.Add("key3", "3");
                    cache.Add("key4", "4");
                    cache.Add("key5", "5");
                    Thread.Sleep(10);
                }
            }
            finally
            {
                //_lock.ExitWriteLock();
            }

        }

        public async Task TaskRunner()
        {


            Parallel.ForEach(Enumerable.Range(0, 10), (item) =>
            {
                Console.WriteLine($"Creating Task {item}");
                while (true)
                {
                    foreach (var index in Enumerable.Range(0, 6))
                    {
                        Cache.TryGetValue($"key{index}", out var val);
                        Console.WriteLine($"task:{item} valor: {val}");
                        //Thread.Sleep(500);

                        if (index == 5)
                        {
                            RenewCache();
                        }
                    }
                }


                Console.WriteLine(item);

            });
            Console.WriteLine("Press any key to exit");

        }
    }
}
