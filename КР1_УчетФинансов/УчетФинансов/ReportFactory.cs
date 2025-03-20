using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class ReportFactory
    {
        public IReport CreateReport(TransactionType transactionType, ReportBuilder reportBuilder, DateTime? startDate = null,
            DateTime? endDate = null)
        {
            startDate ??= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Начало текущего месяца если промежуток времени не задан. 
            endDate ??= DateTime.Now; 

            return transactionType switch
            {
                TransactionType.Income => new IncomeReport(startDate.Value, endDate.Value, reportBuilder),
                TransactionType.Expense => new ExpenseReport(reportBuilder),
                _ => throw new ArgumentException("Неподдерживаемый тип транзакции")
            };
        }
    }
}
