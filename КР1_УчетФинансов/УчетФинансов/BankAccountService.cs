using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    /// <summary>
    /// Сервис для управления банковскими счётами.
    /// </summary>
    public class BankAccountService
    {
        private readonly List<BankAccount> _bankAccounts = new();
        /// <summary>
        /// Создание нового счета
        /// </summary>
        /// <param name="name"></param>
        /// <param name="initialBalance"></param>
        /// <returns></returns>
        public BankAccount Create(string name, decimal initialBalance)
        {
            var newId = _bankAccounts.Any() ? _bankAccounts.Max(a => a.Id) + 1 : 1;
            var account = new BankAccount(newId, name, initialBalance);
            _bankAccounts.Add(account);
            return account;
        }

        /// <summary>
        /// Редактирование существующего счёта.
        /// </summary>
        public bool Update(int accountId, string newName, decimal newBalance)
        {
            var account = _bankAccounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null) 
                return false;

            account.Name = newName;
            account.Balance = newBalance;
            return true;
        }

        /// <summary>
        /// Удаление счёта.
        /// </summary>
        public bool Delete(int accountId)
        {
            var account = _bankAccounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null)
                return false;

            _bankAccounts.Remove(account);
            return true;
        }

        /// <summary>
        /// Получение всех счётов.
        /// </summary>
        public IReadOnlyList<BankAccount> GetAll()
        {
            return _bankAccounts;
        }

        /// <summary>
        /// Получение счёта по Id.
        /// </summary>
        public BankAccount? GetById(int accountId)
        {
            return _bankAccounts.FirstOrDefault(a => a.Id == accountId);
        }
    }
}
