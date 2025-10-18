# Учебные проекты для подготовки к стажировке по C#

Добро пожаловать в мой репозиторий! Здесь собраны выполненные мной задания в рамках учебного курса по C# и платформе .NET. Каждый проект находится в отдельной директории и демонстрирует мои навыки на разных этапах обучения.

### Выполненные задания

| № | Задание | Описание | Папка |
|---|---|---|---|
| 1 | **Консольный калькулятор** | Простое консольное приложение для арифметических операций. | [./Task1_ConsoleCalculator](./Task1_ConsoleCalculator) |
| 2 | **Разбор асинхронности** | Сравнение синхронного и асинхронного выполнения задач. | [./Task2_AsyncDeepDive](./Task2_AsyncDeepDive) |
| 3 | **Менеджер задач** | Консольное CRUD-приложение с использованием Dapper и MS SQL Server. | [./Task3_TaskManager](./Task3_TaskManager) |
| 4 | **Система управления библиотекой (Часть 1)** | **ASP.NET Core Web API** с временным хранилищем в памяти. | [./Task4_LibrarySystem](./Task4_LibrarySystem) |

## 🚀 **Задание 4: Система управления библиотекой (ASP.NET Core Web API)**

Это многослойное Web API приложение для управления каталогом книг и авторов.

*   **Стек:** C#, ASP.NET Core Web API, .NET 8 
*   **Паттерны:** N-слойная архитектура, Repository
*   **Хранилище (Часть 1):** Данные хранятся в коллекциях в памяти (`List<T>`) для имитации работы с базой данных.

#### Эндпоинты API (Часть 1)

**Books Controller (`/api/books`)**
*   `GET /api/books` - Получить все книги.
*   `GET /api/books/{id}` - Получить книгу по ID.
*   `POST /api/books` - Создать новую книгу.
*   `PUT /api/books/{id}` - Обновить существующую книгу.
*   `DELETE /api/books/{id}` - Удалить книгу.

**Authors Controller (`/api/authors`)**
*   `GET /api/authors` - Получить всех авторов.
*   `GET /api/authors/{id}` - Получить автора по ID.
*   `POST /api/authors` - Создать нового автора.
*   `PUT /api/authors/{id}` - Обновить существующего автора.
*   `DELETE /api/authors/{id}` - Удалить автора.

### 🚀 **Задание 3: Консольный менеджер задач**

Консольное CRUD-приложение для управления списком дел.

*   **Стек:** C#, .NET, Dapper, MS SQL Server
*   **Паттерны:** Repository, Factory
*   **Архитектура:** Разделение на UI-слой (`TaskManager`) и ядро (`TaskManager.Core`).

### Быстрый старт

1.  **База данных:** Создайте базу данных `TaskManagerDB` и таблицу `Tasks` с помощью скрипта `DatabaseScripts/Setup_TaskManagerDB.sql`.

2.  **Строка подключения:** В проекте `TaskManager` создайте файл `appsettings.Local.json` и укажите в нем вашу строку подключения к `TaskManagerDB`.
    *Пример:*
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
      }
    }
    ```
    Замените `YOUR_SERVER_NAME` на имя вашего экземпляра SQL Server (например, `.` или `.\SQLEXPRESS`).

3.  **Запуск:** Откройте `TaskManager.sln` и запустите проект `TaskManager`.