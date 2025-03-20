using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public abstract class DataImporter
    {
        public void ImportData(string filePath)
        {
            var data = ReadFile(filePath);
            var parsedData = ParseData(data);
            SaveData(parsedData);
        }

        protected abstract string ReadFile(string filePath);
        protected abstract object ParseData(string data);
        protected abstract void SaveData(object parsedData);
    }
}
