using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace УчетФинансов
{
    public class ExportToCsvVisitor : IVisitor
    {
        private readonly StreamWriter _writer;

        public ExportToCsvVisitor(string filePath)
        {
            _writer = new StreamWriter(filePath);
            _writer.WriteLine("Type,Name,Balance,Description,Amount,Date"); // Заголовки CSV
        }

        public void Visit(BankAccount account)
        {
            _writer.WriteLine($"BankAccount,{account.Name},{account.Balance},,,");
            Console.WriteLine($"Экспорт банковского счёта: {account.Name}, Баланс: {account.Balance}");
        }

        public void Visit(Category category)
        {
            _writer.WriteLine($"Category,{category.Name},,,,{category.Type}");
            Console.WriteLine($"Экспорт категории: {category.Name}, Тип: {category.Type}");
        }

        public void Visit(Operation operation)
        {
            _writer.WriteLine($"Operation,,,{operation.Description},{operation.Amount},{operation.Date}");
            Console.WriteLine($"Экспорт операции: {operation.Description}, Сумма: {operation.Amount}, Дата: {operation.Date}");
        }

        public void Close()
        {
            _writer.Close();
        }
    }
}
