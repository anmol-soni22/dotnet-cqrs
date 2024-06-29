using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services
{
    public class TasksRepository : ITasksRepository
    {
        private readonly DataContext _dbContext;

        public TasksRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Tasks> AddTaskAsync(Tasks task)
        {
            var result = _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteTaskAsync(int Id)
        {
            var filteredData = _dbContext.Tasks.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Tasks.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int Id)
        {
            var filteredData = _dbContext.Tasks.Where(x => x.Id == Id).FirstOrDefault();
            return filteredData;
        }

        public async Task<List<Tasks>> GetTasksListAsync()
        {
            var filteredData = await _dbContext.Tasks.ToListAsync();
            return filteredData;
        }

        public async Task<int> UpdateTaskAsync(Tasks task)
        {
            _dbContext.Tasks.Update(task);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
