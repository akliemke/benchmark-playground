namespace long_running_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public async Task LongRunningOp(CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(async () => {
                await Task.Delay(2000);
            }, 
            cancellationToken,
            TaskCreationOptions.LongRunning, TaskScheduler.Default
           );

        }
    }
}