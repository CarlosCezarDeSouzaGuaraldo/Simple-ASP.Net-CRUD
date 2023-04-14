using Microsoft.EntityFrameworkCore;
using Simple_ASP.Net_CRUD.Data.Map;
using Simple_ASP.Net_CRUD.Models;

namespace Simple_ASP.Net_CRUD.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options)
            : base(options) 
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
