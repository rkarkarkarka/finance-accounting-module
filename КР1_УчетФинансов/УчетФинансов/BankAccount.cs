using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    /// <summary>
    /// Класс, представляющий банковский счёт.
    /// </summary>
    public class BankAccount
    {
        public int Id { get; private set; }
        public string Name { get;  set; }
        public decimal Balance { get;  set; }

        public BankAccount(int id, string name, decimal initialBalance)
        {
            Id = id;
            Name = name;
            Balance = initialBalance;
        }
        public void Accept(IVisitor visitor) //Паттерн "Посетитель"
        {
            visitor.Visit(this);
        }
    }
}