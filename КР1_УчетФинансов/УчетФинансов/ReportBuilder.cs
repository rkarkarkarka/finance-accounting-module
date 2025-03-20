using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class ReportBuilder
    {
        private List<string> _operations = new();

        public void AddOperation(string operation)
        {
            _operations.Add(operation);
        }

        public void PrintReport()
        {
            Console.WriteLine("Отчёт о выполненных операциях:");
            foreach (var operation in _operations)
            {
                Console.WriteLine(operation);
            }
        }

        public string GetReport()
        {
            return string.Join("\n", _operations);
        }
    }
}
