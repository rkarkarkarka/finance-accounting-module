using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class IncomeReport : IReport
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly ReportBuilder _reportBuilder;

        public IncomeReport(DateTime startDate, DateTime endDate, ReportBuilder reportBuilder)
        {
            _startDate = startDate;
            _endDate = endDate;
            _reportBuilder = reportBuilder;
        }

        public void GenerateReport(List<Operation> operations)
        {
            decimal totalIncome = operations
                .Where(op => op.Type == TransactionType.Income && op.Date >= _startDate && op.Date <= _endDate)
                .Sum(op => op.Amount);

            _reportBuilder.AddOperation($"Отчет о доходах с {_startDate.ToShortDateString()} по {_endDate.ToShortDateString()}:");
            _reportBuilder.AddOperation($"Общий доход: {totalIncome}");
        }
    }
}
