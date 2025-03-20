using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class CsvDataImporter : DataImporter
    {
        protected override string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        protected override object ParseData(string data)
        {
            return data.Split('\n');
        }

        protected override void SaveData(object parsedData)
        {
            foreach (var line in (string[])parsedData)
            {
                Console.WriteLine($"Сохранено: {line}");
            }
        }
    }
}
