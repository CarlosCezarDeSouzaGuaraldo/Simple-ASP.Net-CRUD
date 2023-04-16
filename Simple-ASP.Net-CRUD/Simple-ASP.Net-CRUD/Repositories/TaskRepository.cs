using Microsoft.EntityFrameworkCore;
using Simple_ASP.Net_CRUD.Data;
using Simple_ASP.Net_CRUD.Models;
using Simple_ASP.Net_CRUD.Repositories.Interfaces;

namespace Simple_ASP.Net_CRUD.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<TaskModel> FindById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> GetAll()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> Add(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> Update(TaskModel model, int id)
        {
            TaskModel task = await FindById(id);
            if (task == null)
            {
                throw new Exception($"The task with ID: {id} was not found.");
            }

            task.Name = model.Name;
            task.Description = model.Description;
            task.Status = model.Status;
            task.UserId = model.UserId;

            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel task = await FindById(id);
            if (task == null)
            {
                throw new Exception($"The task with ID: {id} was not found.");
            }

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
