// TaskManager.Core.Tests/Repositories/TaskRepositoryTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using System.Linq;
using System;
using Microsoft.Data.Sqlite;
using TaskManager.Core.Models;
using TaskManager.Core.Repositories; // <-- Важно!
using TaskManager.Core.Factories;    // <-- Важно!
using System.Data;                   // <-- Важно!

namespace TaskManager.Core.Tests.Repositories
{
    [TestClass]
    public class TaskRepositoryTests
    {
        [TestMethod]
        public void Full_CRUD_Cycle_Synchronous_Should_Work()
        {
            // Используем using, чтобы соединение гарантированно закрылось в конце
            using (var connection = new SqliteConnection("DataSource=:memory:"))
            {
                // 1. Открываем соединение СИНХРОННО
                connection.Open();

                // 2. Создаем таблицу
                connection.Execute(@"
                    CREATE TABLE Tasks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        IsCompleted INTEGER NOT NULL,
                        CreatedAt TEXT NOT NULL
                    );");

                // --- Теперь, когда среда готова, тестируем наш репозиторий ---

                // Создаем фабрику, которая будет использовать наше открытое соединение
                var factory = new MockSqliteConnectionFactory(connection);
                // Создаем репозиторий
                var repository = new TaskRepository(factory);

                // --- Тест на AddAsync ---
                var newTask = new TaskItem { Title = "Test Add", IsCompleted = false, CreatedAt = DateTime.Now };
                repository.AddAsync(newTask).GetAwaiter().GetResult(); // Вызываем асинхронный метод синхронно

                // --- Тест на GetAllAsync ---
                var allTasks = repository.GetAllAsync().GetAwaiter().GetResult();
                Assert.AreEqual(1, allTasks.Count(), "AddAsync or GetAllAsync failed.");
                var addedTask = allTasks.First();
                Assert.AreEqual("Test Add", addedTask.Title);

                // --- Тест на GetByIdAsync ---
                int newTaskId = addedTask.Id;
                var foundTask = repository.GetByIdAsync(newTaskId).GetAwaiter().GetResult();
                Assert.IsNotNull(foundTask, "GetByIdAsync failed to find the task.");

                // --- Тест на UpdateAsync ---
                foundTask.IsCompleted = true;
                foundTask.Title = "Updated Title";
                repository.UpdateAsync(foundTask).GetAwaiter().GetResult();
                var updatedTask = repository.GetByIdAsync(newTaskId).GetAwaiter().GetResult();
                Assert.IsNotNull(updatedTask, "Task was lost after update.");
                Assert.IsTrue(updatedTask.IsCompleted, "UpdateAsync failed to change status.");
                Assert.AreEqual("Updated Title", updatedTask.Title, "UpdateAsync failed to change title.");

                // --- Тест на DeleteAsync ---
                repository.DeleteAsync(newTaskId).GetAwaiter().GetResult();
                var deletedTask = repository.GetByIdAsync(newTaskId).GetAwaiter().GetResult();
                Assert.IsNull(deletedTask, "DeleteAsync failed to remove the task.");
            }
        }
    }

    // Вспомогательная фабрика для "подмены" соединения
    public class MockSqliteConnectionFactory : IDbConnectionFactory
    {
        private readonly IDbConnection _connection;
        public MockSqliteConnectionFactory(IDbConnection connection) { _connection = connection; }
        public IDbConnection CreateConnection() { return _connection; }
    }
}