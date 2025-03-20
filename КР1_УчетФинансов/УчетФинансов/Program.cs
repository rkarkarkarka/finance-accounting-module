using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace УчетФинансов
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка DI-контейнера
            var serviceProvider = new ServiceCollection()
                .AddSingleton<BankAccountService>()
                .AddSingleton<BankAccountFacade>()
                .AddSingleton<CategoryService>()
                .AddSingleton<CategoryFacade>()
                .AddSingleton<OperationService>()
                .AddSingleton<OperationFacade>()
                .AddTransient<ReportBuilder>()
                .AddSingleton<ReportFactory>()
                .AddSingleton<ExportToCsvVisitor>()
                .AddSingleton<AccountingSession>()
                .BuildServiceProvider();

            // Получение экземпляров через DI-контейнер
            var bankAccountFacade = serviceProvider.GetService<BankAccountFacade>();
            var categoryFacade = serviceProvider.GetService<CategoryFacade>();
            var operationFacade = serviceProvider.GetService<OperationFacade>();
            var reportFactory = serviceProvider.GetService<ReportFactory>();

            // Создание объектов через фасады
            // Создание банковского счета
            var bankAccount = bankAccountFacade.CreateAccount("Основной счет", 1000);

            // Создание категорий
            var foodCategory = categoryFacade.CreateCategory(TransactionType.Expense, "Продукты");
            var clothingCategory = categoryFacade.CreateCategory(TransactionType.Expense, "Одежда");
            var incomeCategory = categoryFacade.CreateCategory(TransactionType.Income, "Зарплата");

            // Создание операций
            operationFacade.CreateOperation(TransactionType.Income, bankAccount.Id, 300, DateTime.Now.AddDays(-5), "Продажа товаров", incomeCategory.Id);
            operationFacade.CreateOperation(TransactionType.Expense, bankAccount.Id, 150, DateTime.Now.AddDays(-3), "Покупка продуктов", foodCategory.Id);
            operationFacade.CreateOperation(TransactionType.Expense, bankAccount.Id, 100, DateTime.Now.AddDays(-1), "Покупка одежды", clothingCategory.Id);
            operationFacade.CreateOperation(TransactionType.Income, bankAccount.Id, 200, DateTime.Now.AddDays(-2), "Дополнительный доход", incomeCategory.Id);

            // Использование паттерна Фасад для получения всех операций
            var operations = operationFacade.GetAllOperations();

            // Использование паттерна фабрика для генерации отчетов
            var reportBuilder = serviceProvider.GetService<ReportBuilder>();
            // Генерация отчета о доходах
            var incomeReport = reportFactory.CreateReport(TransactionType.Income, reportBuilder, DateTime.Now.AddDays(-7), DateTime.Now);
            incomeReport.GenerateReport(operations.ToList());
            reportBuilder.PrintReport();
            // Генерация отчета о расходах
            reportBuilder = serviceProvider.GetService<ReportBuilder>(); // Создаем новый ReportBuilder для нового отчета
            var expenseReport = reportFactory.CreateReport(TransactionType.Expense, reportBuilder);
            expenseReport.GenerateReport(operations.ToList());
            reportBuilder.PrintReport();

            // Использование паттерна Посетитель
            var reportGenerator = new ExportToCsvVisitor("report.csv");

            foreach (var operation in operations)
            {
                operation.Accept(reportGenerator);
            }
            reportGenerator.Close();

            // Пример использования паттерна Команда
            var commandManager = serviceProvider.GetService<AccountingSession>();
            var operationService = serviceProvider.GetService<OperationService>();
            commandManager.AddCommand(new CreateOperationCommand(operationService, TransactionType.Income, bankAccount.Id, 500, DateTime.Now, "Новая продажа", incomeCategory.Id));
            commandManager.AddCommand(new CreateOperationCommand(operationService, TransactionType.Expense, bankAccount.Id, 200, DateTime.Now, "Новая покупка", foodCategory.Id));
            commandManager.AddCommand(new CreateOperationCommand(operationService, TransactionType.Expense, bankAccount.Id, 100, DateTime.Now, "Покупка одежды", clothingCategory.Id));
            commandManager.AddCommand(new CreateOperationCommand(operationService, TransactionType.Income, bankAccount.Id, 300, DateTime.Now, "Дополнительный доход", incomeCategory.Id));
            // Отменяем последние 2 команды
            commandManager.Undo(); 
            commandManager.Undo();
            commandManager.Redo(); // Повторно выполняем отмененную команду
            commandManager.SaveChanges();

            // Печать обновленного отчета о доходах
            reportBuilder = serviceProvider.GetService<ReportBuilder>();
            var updatedOperations = operationFacade.GetAllOperations().ToList();
            var updatedReport = reportFactory.CreateReport(TransactionType.Income, reportBuilder);
            updatedReport.GenerateReport(updatedOperations);
            reportBuilder.PrintReport();

            // Пример использования паттерна Декоратор
            var decoratedOperation = new TimingCommandDecorator(new CreateOperationCommand(operationService, TransactionType.Income, bankAccount.Id, 300, DateTime.Now, "Продажа с налогом", incomeCategory.Id));
            decoratedOperation.Apply();

            // Пример использования паттерна Шаблонный метод
            var specificIncomeReport = new IncomeReport(DateTime.Now.AddDays(-7), DateTime.Now, reportBuilder);
            specificIncomeReport.GenerateReport(operations.ToList());
        }
    }
}