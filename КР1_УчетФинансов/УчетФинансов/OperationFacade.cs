using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class OperationFacade
    {
        private readonly OperationService _operationService;

        public OperationFacade(OperationService operationService)
        {
            _operationService = operationService;
        }

        public Operation CreateOperation(TransactionType type, int bankAccountId, decimal amount, DateTime date, string? description, int categoryId)
        {
            return _operationService.Create(type, bankAccountId, amount, date, description, categoryId);
        }

        public bool UpdateOperation(int operationId, TransactionType newType, int newBankAccountId, decimal newAmount, DateTime newDate, string? newDescription, int newCategoryId)
        {
            return _operationService.Update(operationId, newType, newBankAccountId, newAmount, newDate, newDescription, newCategoryId);
        }

        public bool DeleteOperation(int operationId)
        {
            return _operationService.Delete(operationId);
        }

        public IReadOnlyList<Operation> GetAllOperations()
        {
            return _operationService.GetAll();
        }

        public Operation? GetOperationById(int operationId)
        {
            return _operationService.GetById(operationId);
        }
    }
}
