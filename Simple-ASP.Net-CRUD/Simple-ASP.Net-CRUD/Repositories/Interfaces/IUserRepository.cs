using Simple_ASP.Net_CRUD.Models;

namespace Simple_ASP.Net_CRUD.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> FindById(int id);
        Task<UserModel> Add(UserModel model);
        Task<UserModel> Update(UserModel model, int id);
        Task<bool> Delete(int id);
    }
}
