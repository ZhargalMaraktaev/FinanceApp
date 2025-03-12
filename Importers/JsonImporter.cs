using FinanceApp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

public class JsonImporter : DataImporter
{
    protected override string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    protected override void ParseData(string data)
    {
        Console.WriteLine("Parsing JSON data...");

        try
        {
            // Десериализация JSON-файла
            var json = JsonConvert.DeserializeObject<JObject>(data);
            var operations = json["operations"].ToObject<List<Operation>>();

            // Вывод данных о каждой операции
            foreach (var operation in operations)
            {
                Console.WriteLine($"Operation: {operation.Description}, Amount: {operation.Amount}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing JSON: {ex.Message}");
        }
    }
}
