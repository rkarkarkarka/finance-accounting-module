using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace УчетФинансов
{
    public class ExportToJsonVisitor : IVisitor
    {
        private readonly List<object> _exportedData = new();

        public void Visit(BankAccount account)
        {
            var data = new
            {
                Type = "BankAccount",
                Name = account.Name,
                Balance = account.Balance
            };
            _exportedData.Add(data);
            Console.WriteLine($"Экспорт банковского счёта: {account.Name}, Баланс: {account.Balance}");
        }

        public void Visit(Category category)
        {
            var data = new
            {
                Type = "Category",
                Name = category.Name,
                TransactionType = category.Type
            };
            _exportedData.Add(data);
            Console.WriteLine($"Экспорт категории: {category.Name}, Тип: {category.Type}");
        }

        public void Visit(Operation operation)
        {
            var data = new
            {
                Type = "Operation",
                Description = operation.Description,
                Amount = operation.Amount,
                Date = operation.Date
            };
            _exportedData.Add(data);
            Console.WriteLine($"Экспорт операции: {operation.Description}, Сумма: {operation.Amount}, Дата: {operation.Date}");
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(_exportedData, Formatting.Indented);
        }
    }
}
