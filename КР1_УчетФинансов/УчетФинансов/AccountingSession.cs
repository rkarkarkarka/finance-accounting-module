using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class AccountingSession
    {
        private readonly List<IAccountingSessionCommand> _unappliedCommands = new();
        private readonly Stack<IAccountingSessionCommand> _undoneCommands = new();
        private readonly ReportBuilder _reportBuilder = new();

        public void AddCommand(IAccountingSessionCommand command)
        {
            command.Apply();
            _unappliedCommands.Add(command);
            _undoneCommands.Clear(); // Очистка стека отменённых команд при добавлении новой
        }

        public void Undo()
        {
            if (_unappliedCommands.Count == 0) return;

            var command = _unappliedCommands[^1]; // Получаем последнюю команду
            _unappliedCommands.RemoveAt(_unappliedCommands.Count - 1);
            _undoneCommands.Push(command);
        }

        public void Redo()
        {
            if (_undoneCommands.Count == 0) return;

            var command = _undoneCommands.Pop();
            command.Apply();
            _unappliedCommands.Add(command);
        }

        public IReadOnlyList<IAccountingSessionCommand> GetPendingCommands()
        {
            return _unappliedCommands.AsReadOnly();
        }

        public void SaveChanges()
        {
            foreach (var command in _unappliedCommands)
            {
                command.Apply();

                var operation = command.ToString();

                if (operation is not null)
                {
                    _reportBuilder.AddOperation(operation);
                }
            }

            // После сохранения очищаем списки команд
            _unappliedCommands.Clear();
            _undoneCommands.Clear();
            // Печатаем отчёт о выполненных операциях
            _reportBuilder.PrintReport();
        }
    }
}