using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Exporters
{
    public class JsonExporter
    {
        public void ExportData(List<Operation> operations, string filePath)
        {
            var json = JsonConvert.SerializeObject(operations, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Data exported to {filePath}");
        }
    }

}
