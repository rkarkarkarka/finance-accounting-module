using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public abstract class CommandDecorator : IAccountingSessionCommand
    {
        protected IAccountingSessionCommand _command;

        protected CommandDecorator(IAccountingSessionCommand command)
        {
            _command = command;
        }

        public virtual void Apply()
        {
            _command.Apply();
        }
    }
}
