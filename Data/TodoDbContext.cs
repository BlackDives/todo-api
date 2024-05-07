using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using todo_rest_api.Models;
using Microsoft.AspNetCore.Identity;

namespace todo_rest_api.Data
{
    public class TodoDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole<int>> roles = new List<IdentityRole<int>>
            {
                new IdentityRole<int>
                {
                  Id = 1,
                  Name = "Admin",
                  NormalizedName = "ADMIN"
                },
                 new IdentityRole<int>
                {
                  Id = 2,
                  Name = "User",
                  NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole<int>>().HasData(roles);
        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }

    }
}
