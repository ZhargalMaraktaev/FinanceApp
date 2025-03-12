using FinanceApp.Exporters;
using FinanceApp;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var categoryFacade = new CategoryFacade();
        var analyticsService = new AnalyticsService();
        var balanceService = new BalanceService();
        var jsonExporter = new JsonExporter();
        var operations = new List<Operation>();

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить категорию");
            Console.WriteLine("2. Добавить операцию");
            Console.WriteLine("3. Показать аналитику");
            Console.WriteLine("4. Экспортировать данные в JSON");
            Console.WriteLine("5. Выйти");
            Console.Write("Ваш выбор: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите ID категории: ");
                    var categoryId = int.Parse(Console.ReadLine());
                    Console.Write("Введите тип категории (Income/Expense): ");
                    var categoryType = Console.ReadLine();
                    Console.Write("Введите название категории: ");
                    var categoryName = Console.ReadLine();

                    var category = new Category { Id = categoryId, Type = categoryType, Name = categoryName };
                    ICommand addCategoryCommand = new AddCategoryCommand(categoryFacade, category);
                    ICommand decoratedCommand = new CommandDecorator(addCategoryCommand);
                    decoratedCommand.Execute();
                    break;

                case "2":
                    Console.Write("Введите ID операции: ");
                    var operationId = int.Parse(Console.ReadLine());
                    Console.Write("Введите тип операции (Income/Expense): ");
                    var operationType = Console.ReadLine();
                    Console.Write("Введите ID счета: ");
                    var bankAccountId = int.Parse(Console.ReadLine());
                    Console.Write("Введите сумму: ");
                    var amount = decimal.Parse(Console.ReadLine());
                    Console.Write("Введите описание: ");
                    var description = Console.ReadLine();
                    Console.Write("Введите ID категории: ");
                    var operationCategoryId = int.Parse(Console.ReadLine());

                    var operation = OperationFactory.CreateOperation(operationId, operationType, bankAccountId, amount, DateTime.Now, description, operationCategoryId);
                    operations.Add(operation);
                    Console.WriteLine("Операция добавлена.");
                    break;

                case "3":
                    Console.Write("Введите начальную дату (yyyy-MM-dd): ");
                    var startDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Введите конечную дату (yyyy-MM-dd): ");
                    var endDate = DateTime.Parse(Console.ReadLine());

                    var netIncome = analyticsService.CalculateNetIncome(operations, startDate, endDate);
                    Console.WriteLine($"Чистый доход: {netIncome}");

                    var groupedByCategory = analyticsService.GroupByCategory(operations);
                    foreach (var group in groupedByCategory)
                    {
                        Console.WriteLine($"Категория {group.Key}: {group.Value}");
                    }
                    break;

                case "4":
                    jsonExporter.ExportData(operations, "exported_data.json");
                    Console.WriteLine("Данные экспортированы в файл exported_data.json");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
