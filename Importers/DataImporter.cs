using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public abstract class DataImporter
    {
        public void ImportData(string filePath)
        {
            var data = ReadFile(filePath);
            ParseData(data);
        }

        protected abstract string ReadFile(string filePath);
        protected abstract void ParseData(string data);
    }

}
