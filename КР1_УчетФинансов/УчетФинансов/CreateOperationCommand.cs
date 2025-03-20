using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class CreateOperationCommand : IAccountingSessionCommand
    {
        private readonly OperationService _operationService;
        private readonly TransactionType _type;
        private readonly int _bankAccountId;
        private readonly decimal _amount;
        private readonly DateTime _date;
        private readonly string? _description;
        private readonly int _categoryId;

        public CreateOperationCommand(OperationService operationService, TransactionType type, int bankAccountId, decimal amount, DateTime date, string? description, int categoryId)
        {
            _operationService = operationService;
            _type = type;
            _bankAccountId = bankAccountId;
            _amount = amount;
            _date = date;
            _description = description;
            _categoryId = categoryId;
        }

        public void Apply()
        {
            _operationService.Create(_type, _bankAccountId, _amount, _date, _description, _categoryId);
        }

        public override string ToString()
        {
            return $"Создана операция: {_description ?? "Без описания"}, Сумма: {_amount}, Дата: {_date}";
        }
    }
}
