using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public interface IVisitor
    {
        void Visit(BankAccount account);
        void Visit(Category category);
        void Visit(Operation operation);
    }
}
