using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}