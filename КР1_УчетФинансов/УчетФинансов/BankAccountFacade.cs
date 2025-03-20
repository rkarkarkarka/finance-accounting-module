using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class BankAccountFacade
    {
        private readonly BankAccountService _bankAccountService;

        public BankAccountFacade(BankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public BankAccount CreateAccount(string name, decimal initialBalance)
        {
            return _bankAccountService.Create(name, initialBalance);
        }

        public bool UpdateAccount(int accountId, string newName, decimal newBalance)
        {
            return _bankAccountService.Update(accountId, newName, newBalance);
        }

        public bool DeleteAccount(int accountId)
        {
            return _bankAccountService.Delete(accountId);
        }

        public IReadOnlyList<BankAccount> GetAllAccounts()
        {
            return _bankAccountService.GetAll();
        }

        public BankAccount? GetAccountById(int accountId)
        {
            return _bankAccountService.GetById(accountId);
        }
    }
}
