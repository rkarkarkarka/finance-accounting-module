using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    /// <summary>
    /// Класс, представляющий категорию.
    /// </summary>
    public class Category
    {
        public int Id { get; private set; }
        public TransactionType Type { get; set; }
        public string Name { get; set; }

        public Category(int id, TransactionType type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
        }
        public void Accept(IVisitor visitor) //Паттерн "Посетитель"
        {
            visitor.Visit(this);
        }
    }
}
