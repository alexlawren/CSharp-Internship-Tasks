using Microsoft.Data.Sqlite;
using System.Data;
using TaskManager.Core.Factories; // Важно, чтобы был using для интерфейса

namespace TaskManager.Core.Tests.Mocks
{
    // Эта фабрика реализует тот же интерфейс, что и настоящая
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        private readonly IDbConnection _connection;

        // Она будет хранить ОДНО открытое подключение, чтобы БД в памяти не исчезала
        public SqliteConnectionFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }

        // Каждый раз, когда репозиторий попросит подключение, мы будем давать ему это
        public IDbConnection CreateConnection()
        {
            return _connection;
        }

        // Метод для очистки после тестов
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}