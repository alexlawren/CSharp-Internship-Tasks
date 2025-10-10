using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Factories;
using TaskManager.Core.Models;

namespace TaskManager.Core.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public TaskRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(TaskItem task)
        {
            string sql = "INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt) VALUES (@Title, @Description, @IsCompleted, @CreatedAt);";
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                await db.ExecuteAsync(sql, task);
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            string sql = "SELECT * FROM Tasks;";
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                return await db.QueryAsync<TaskItem>(sql);
            }
        }

        public async Task UpdateAsync(TaskItem task)
        {
            string sql = "UPDATE Tasks SET IsCompleted = @IsCompleted WHERE Id = @Id;";
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                await db.ExecuteAsync(sql, task);
            }
        }

        public async Task DeleteAsync(int id)
        {
            string sql = "DELETE FROM Tasks WHERE Id = @Id;";
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                await db.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<TaskItem> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Tasks WHERE Id = @Id;";
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {

                return await db.QueryFirstOrDefaultAsync<TaskItem>(sql, new { Id = id });
            }

        }
    }
}
