using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class ExpenseReport : IReport
    {
        private readonly ReportBuilder _reportBuilder;

        public ExpenseReport(ReportBuilder reportBuilder)
        {
            _reportBuilder = reportBuilder;
        }

        public void GenerateReport(List<Operation> operations)
        {
            var totalExpense = operations
                .Where(op => op.Type == TransactionType.Expense)
                .Sum(op => op.Amount);

            _reportBuilder.AddOperation("Отчет о расходах:");
            _reportBuilder.AddOperation($"Общие расходы: {totalExpense}");
        }
    }
}
