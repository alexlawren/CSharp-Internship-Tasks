using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Core.Models;

namespace TaskManager.Core.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem> GetByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);

    }
}
