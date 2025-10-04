using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWork
{
    public class DataProcessor
    {
        private const int ProcessingTimeSeconds = 3;

        public string ProcessData(string dataName)
        {
            Thread.Sleep(ProcessingTimeSeconds * 1000);
            return CreateResult(dataName);
        }

        public async Task<string> ProcessDataAsync(string dataName)
        {
            await Task.Delay(ProcessingTimeSeconds * 1000);
            return CreateResult(dataName);
        }

        public string CreateResult(string dataName)
        {
            return $"Обработка {dataName} завершена за {ProcessingTimeSeconds} секунды.";
        }
    }

}
