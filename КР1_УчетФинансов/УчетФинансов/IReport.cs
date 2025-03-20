using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    /// <summary>
    /// Отчеты по операциям
    /// </summary>
    public interface IReport
    {
        void GenerateReport(List<Operation> operations);
    }
}
