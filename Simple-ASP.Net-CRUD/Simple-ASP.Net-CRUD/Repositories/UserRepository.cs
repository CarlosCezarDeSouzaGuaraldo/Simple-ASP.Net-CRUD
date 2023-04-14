using Microsoft.EntityFrameworkCore;
using Simple_ASP.Net_CRUD.Data;
using Simple_ASP.Net_CRUD.Models;
using Simple_ASP.Net_CRUD.Repositories.Interfaces;

namespace Simple_ASP.Net_CRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<UserModel> FindById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Add(UserModel model)
        {
            await _dbContext.Users.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<UserModel> Update(UserModel model, int id)
        {
            UserModel user = await FindById(id);
            if (user == null)
            {
                throw new Exception($"The user with ID: {id} was not found.");
            }

            user.Name = model.Name;
            user.Email = model.Email;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel user = await FindById(id);
            if (user == null)
            {
                throw new Exception($"The user with ID: {id} was not found.");
            }
            
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
