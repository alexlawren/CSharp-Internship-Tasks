# Учебные проекты для подготовки к стажировке по C#

Добро пожаловать в мой репозиторий! Здесь собраны выполненные мной задания в рамках учебного курса по C# и платформе .NET. Каждый проект находится в отдельной директории и демонстрирует мои навыки на разных этапах обучения.

### Выполненные задания

| № | Задание | Описание | Папка |
|---|---|---|---|
| 1 | **Консольный калькулятор** | Простое консольное приложение для арифметических операций. | [./Task1_ConsoleCalculator](./Task1_ConsoleCalculator) |
| 2 | **Разбор асинхронности** | Сравнение синхронного и асинхронного выполнения задач. | [./Task2_AsyncDeepDive](./Task2_AsyncDeepDive) |
| 3 | **Менеджер задач** | Консольное CRUD-приложение с использованием Dapper и MS SQL Server. | [./Task3_TaskManager](./Task3_TaskManager) |
| 4 | **Система управления библиотекой** | **ASP.NET Core Web API** с N-слойной архитектурой и Entity Framework. | [./Task4_LibrarySystem](./Task4_LibrarySystem) |

## 🚀 Задание 4: Система управления библиотекой (ASP.NET Core Web API)

Это многослойное Web API приложение для управления каталогом книг и авторов, построенное на принципах чистой архитектуры.

### 🌟 Часть 2: Интеграция с базой данных (Entity Framework Core)

В этой версии проект был значительно доработан: временное хранилище в памяти заменено на полноценную базу данных с использованием **Entity Framework Core**.

*   **Стек:** C#, ASP.NET Core Web API, .NET 8, **Entity Framework Core**, **SQLite**.
*   **Архитектура и Паттерны:**
    *   **N-Layer Architecture** с физическим разделением на проекты (`Domain`, `Application`, `Infrastructure`, `API`).
    *   **Repository Pattern** для изоляции логики доступа к данным.
    *   **Dependency Injection (DI)** для слабой связанности компонентов.
    *   **DTO (Data Transfer Objects)** для создания безопасного и стабильного API-контракта.
*   **Инструменты:**
    *   **AutoMapper** для автоматизации преобразования объектов.
    *   **FluentValidation** для мощной и чистой валидации входящих данных.
    *   **Централизованная обработка ошибок** через `Middleware`.
*   **База данных:**
    *   **Code First** подход для управления схемой БД.
    *   **EF Core Migrations** для контроля версий базы данных.
    *   **Seed Data** для предзаполнения базы начальными данными.

---

#### Эндпоинты API

##### Books Controller (`/api/books`)
*   `GET /api/books` - Получить все книги (с **пагинацией**).
*   `GET /api/books/{id}` - Получить книгу по ID.
*   `GET /api/books/published-after/{year}` - **(LINQ)** Получить книги, опубликованные после указанного года.
*   `POST /api/books` - Создать новую книгу.
*   `PUT /api/books/{id}` - Обновить существующую книгу.
*   `DELETE /api/books/{id}` - Удалить книгу.

##### Authors Controller (`/api/authors`)
*   `GET /api/authors` - Получить всех авторов (с **пагинацией**).
*   `GET /api/authors/with-book-count` - **(LINQ)** Получить всех авторов с количеством их книг (с **пагинацией**).
*   `GET /api/authors/{id}` - Получить автора по ID.
*   `GET /api/authors/search/{nameQuery}` - **(LINQ)** Найти автора по части имени.
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