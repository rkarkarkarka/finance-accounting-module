using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    /// <summary>
    /// Класс, представляющий операцию по счёту.
    /// </summary>
    public class Operation
    {
        public int Id { get; private set; }
        public TransactionType Type { get; set; }
        public int BankAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }

        public Operation(int id, TransactionType type, int bankAccountId, decimal amount, DateTime date, string? description, int categoryId)
        {
            Id = id;
            Type = type;
            BankAccountId = bankAccountId;
            Amount = amount;
            Date = date;
            Description = description;
            CategoryId = categoryId;
        }
        public void Accept(IVisitor visitor) //Паттерн "Посетитель"
        {
            visitor.Visit(this);
        }

    }
}
