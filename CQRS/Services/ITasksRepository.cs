using CQRS.Models;

namespace CQRS.Services
{
    public interface ITasksRepository
    {
        public Task<List<Tasks>> GetTasksListAsync();
        public Task<Tasks> GetTaskByIdAsync(int Id);
        public Task<Tasks> AddTaskAsync(Tasks task);
        public Task<int> UpdateTaskAsync(Tasks task);
        public Task<int> DeleteTaskAsync(int Id);
    }
}
