using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class JsonDataImporter : DataImporter
    {
        protected override string ReadFile(string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }

        protected override object ParseData(string data)
        {
            var parsedData = JsonConvert.DeserializeObject<List<Operation>>(data);
            if (parsedData == null)
            {
                throw new InvalidOperationException("Данные не могут быть десериализованы.");
            }
            return parsedData;
        }

        protected override void SaveData(object parsedData)
        {
            Console.WriteLine($"Сохранено: {parsedData}");
        }
    }
}
