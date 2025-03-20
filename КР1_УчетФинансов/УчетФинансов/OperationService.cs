using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class OperationService
    {
        private readonly List<Operation> _operations = new();

        public Operation Create(TransactionType type, int bankAccountId, decimal amount, DateTime date, string? description, int categoryId)
        {
            var newId = _operations.Any() ? _operations.Max(o => o.Id) + 1 : 1;
            var operation = new Operation(newId, type, bankAccountId, amount, date, description, categoryId);
            _operations.Add(operation);
            return operation;
        }

        public bool Update(int operationId, TransactionType newType, int newBankAccountId, decimal newAmount, DateTime newDate, string? newDescription, int newCategoryId)
        {
            var operation = _operations.FirstOrDefault(o => o.Id == operationId);
            if (operation == null)
                return false;

            operation.Type = newType;
            operation.BankAccountId = newBankAccountId;
            operation.Amount = newAmount;
            operation.Date = newDate;
            operation.Description = newDescription;
            operation.CategoryId = newCategoryId;
            return true;
        }

        public bool Delete(int operationId)
        {
            var operation = _operations.FirstOrDefault(o => o.Id == operationId);
            if (operation == null)
                return false;

            _operations.Remove(operation);
            return true;
        }

        public IReadOnlyList<Operation> GetAll()
        {
            return _operations;
        }

        public Operation? GetById(int operationId)
        {
            return _operations.FirstOrDefault(o => o.Id == operationId);
        }
    }
}
