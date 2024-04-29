﻿using Microsoft.EntityFrameworkCore;
using todo_rest_api.Models;

namespace todo_rest_api.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }

    }
}