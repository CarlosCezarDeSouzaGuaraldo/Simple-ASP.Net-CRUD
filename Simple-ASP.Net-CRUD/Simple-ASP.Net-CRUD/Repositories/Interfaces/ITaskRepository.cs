using Simple_ASP.Net_CRUD.Models;

namespace Simple_ASP.Net_CRUD.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> FindById(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task, int id);
        Task<bool> Delete(int id);
    }
}
