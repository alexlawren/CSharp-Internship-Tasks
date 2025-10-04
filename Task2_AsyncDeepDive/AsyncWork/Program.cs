using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWork
{
    internal class Program
    {
        private static readonly List<string> DataToProcess = new List<string> { "Файл 1", "Файл 2", "Файл 3" };
        static async Task Main(string[] args)
        {
            Console.WriteLine("Демонстрация синхронного и асинхронного выполнения\n");
            RunSynchronousDemo();
            await RunAsynchronousDemo();
            Console.WriteLine("\nНажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

        private static void RunSynchronousDemo()
        {
            Console.WriteLine("Начинаем синхронную обработку");
            var processor = new DataProcessor();
            var stopwatch = Stopwatch.StartNew();

            foreach (var data in DataToProcess)
            {
                Console.WriteLine(processor.ProcessData(data));
            }
            stopwatch.Stop();
            Console.WriteLine($"Синхронная обработка заняла: {stopwatch.Elapsed.TotalSeconds} секунд");
        }

        private static async Task RunAsynchronousDemo()
        {
            Console.WriteLine("Начинаем асинхронную обработку");
            var processor = new DataProcessor();
            var stopwatch = Stopwatch.StartNew();

            var runningTask = DataToProcess.Select(data => processor.ProcessDataAsync(data)).ToList();

            while (runningTask.Any())
            {
                Task<string> completedTask = await Task.WhenAny(runningTask);
                Console.WriteLine(await completedTask);

                runningTask.Remove(completedTask);
            }

            stopwatch.Stop();
            Console.WriteLine($"\nАсинхронная обработка заняла: {stopwatch.Elapsed.TotalSeconds} секунд.");
        }

    }
}
