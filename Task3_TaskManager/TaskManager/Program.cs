using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Factories;
using TaskManager.Core.Models;
using TaskManager.Core.Repositories;

namespace TaskManager
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string connectionString = ConfigurationLoader.GetConnectionString();

                var factory = new SqlConnectionFactory(connectionString);

                ITaskRepository repository = new TaskRepository(factory);

                Console.WriteLine("Проверка подключения к базе данных...");
                await repository.GetAllAsync();
                Console.WriteLine("Подключение успешно!");
                PauseForUser();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Консольный менеджер задач");

                    await ShowAllTaskAsync(repository);
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1. Добавить задачу");
                    Console.WriteLine("2. Обновить статус задачи");
                    Console.WriteLine("3. Удалить задачу");
                    Console.WriteLine("4. Посмотреть детали задачи");
                    Console.WriteLine("5. Выйти");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            await AddTaskAsync(repository);
                            break;
                        case "2":
                            await UpdateTaskAsync(repository);
                            break;
                        case "3":
                            await DeleteTaskAsync(repository);
                            break;
                        case "4":
                            await ShowTaskDetailsAsync(repository);
                            break;
                        case "5":
                            Console.WriteLine("Работа завершена");
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова");
                            break;
                    }

                    if (choice != "5")
                    {
                        PauseForUser();
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Clear();
                Console.WriteLine("КРИТИЧЕСКАЯ ОШИБКА: Не удалось подключиться к базе данных.");
                Console.WriteLine("Пожалуйста, убедитесь, что SQL Server запущен и строка подключения верна.");
                Console.WriteLine("\nТехнические детали");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Произошла критическая, непредвиденная ошибка!");
                Console.WriteLine("Приложение не может продолжать работу.");
                Console.WriteLine("\nТехнические детали");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("\nНажмите любую клавишу для выхода.");
            }


        }

        private static async Task ShowAllTaskAsync(ITaskRepository repository)
        {
            Console.WriteLine("Список задач");
            try
            {
                var tasks = await repository.GetAllAsync();
                if (!tasks.Any())
                {
                    Console.WriteLine("Список задач пуст");
                    return;
                }

                foreach (var task in tasks)
                {
                    string status = task.IsCompleted ? "[x]" : "[ ]";
                    Console.WriteLine($"{task.Id}. {status} {task.Title}");
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении задач: {ex.Message}");
            }
        }

        private static async Task AddTaskAsync(ITaskRepository repository)
        {
            Console.WriteLine("\nДобавление новой задачи");
            try
            {
                string title;

                while (true)
                {
                    Console.WriteLine("Введите название задачи (обязательно)");
                    title = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        break;
                    }
                    Console.WriteLine("Название задачи не может быть пустым. Пожулайста, попробуйте снова");
                }

                Console.WriteLine("Введите описание задачи (необязательно, нажмите enter чтобы пропустить)");
                string description = Console.ReadLine();

                var newTask = new TaskItem
                {
                    Title = title,
                    Description = description,
                    IsCompleted = false,
                    CreatedAt = DateTime.Now,
                };

                await repository.AddAsync(newTask);
                Console.WriteLine("Задача успешно добавлена!");
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка при добавлении задачи: {ex.Message}");
            }
        }

        private static async Task UpdateTaskAsync(ITaskRepository repository)
        {
            Console.WriteLine("\nОбновление статуса задачи");
            try
            {

                int id = GetTaskIdFromUser();


                var taskToUpdate = await repository.GetByIdAsync(id);

                if (taskToUpdate == null)
                {
                    Console.WriteLine($"Ошибка: Задача с ID = {id} не найдена.");
                    return;
                }
                taskToUpdate.IsCompleted = !taskToUpdate.IsCompleted;

                string newStatus = taskToUpdate.IsCompleted ? "Выполнена" : "Не выполнена";
                Console.WriteLine($"Новый статус для задачи '{taskToUpdate.Title}': {newStatus}");

                await repository.UpdateAsync(taskToUpdate);

                Console.WriteLine("Статус задачи успешно обновлен!");
            }

            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка при обновлении задачи: {ex.Message}");
            }
        }

        private static async Task DeleteTaskAsync(ITaskRepository repository)
        {
            Console.WriteLine("\nУдаление заадчи");
            try
            {
                int id = GetTaskIdFromUser();

                var taskToDelete = await repository.GetByIdAsync(id);
                if (taskToDelete == null)
                {
                    Console.WriteLine($"Ошибка: Задача с ID = {id} не найдена.");
                    return;
                }

                Console.WriteLine($"Вы уверены, что хотите удалить задачу: '{taskToDelete.Title}'?");
                Console.Write("Введите 'да' для подтверждения: ");

                string confirmation = Console.ReadLine();
                if (confirmation.ToLower() != "да")
                {
                    Console.WriteLine("Удаление отменено");
                    return;
                }

                await repository.DeleteAsync(id);


                Console.WriteLine("Задача успешно удалена!");
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка при удалении задачи: {ex.Message}");
            }
        }

        private static async Task ShowTaskDetailsAsync(ITaskRepository repository)
        {
            Console.WriteLine("\nПросмотр деталей задачи");
            try
            {
                int id = GetTaskIdFromUser();

                var task = await repository.GetByIdAsync(id);
                if (task == null)
                {
                    Console.WriteLine($"Задача с ID = {id} не найдена.");
                    return;
                }

                Console.WriteLine("\nДетали задачи");
                Console.WriteLine($"ID:            {task.Id}");
                Console.WriteLine($"Название:      {task.Title}");
                Console.WriteLine($"Описание:      {(string.IsNullOrWhiteSpace(task.Description) ? "Отсутствует" : task.Description)}");
                Console.WriteLine($"Статус:        {(task.IsCompleted ? "Выполнена" : "В работе")}");
                Console.WriteLine($"Дата создания: {task.CreatedAt:dd.MM.yyyy HH:mm}");
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nОшибка при просмотре деталей задачи: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void PauseForUser()
        {
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private static int GetTaskIdFromUser()
        {
            int id;
            while (true)
            {
                Console.Write("\nВведите ID задачи: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out id))
                {
                    return id;
                }
                Console.WriteLine("Некорректный ID. Пожалуйста, введите целое число.");
            }
        }
    }
}

