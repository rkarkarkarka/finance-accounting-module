using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class TimingCommandDecorator : CommandDecorator
    {
        public TimingCommandDecorator(IAccountingSessionCommand command) : base(command)
        {
        }

        public override void Apply()
        {
            var startTime = DateTime.Now;
            base.Apply();
            var endTime = DateTime.Now;
            Console.WriteLine($"Время исполнения команды: {endTime - startTime}");
        }
    }
}
