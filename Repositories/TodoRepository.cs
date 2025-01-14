using System.Collections.Generic;
using System.Linq;
using TodoApp.Data;
using ToDoList.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetAll() => _context.TodoItems.ToList();

        public TodoItem GetById(int id) => _context.TodoItems.FirstOrDefault(t => t.Id == id);

        public void Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
        }

        public void Update(TodoItem item)
        {
            _context.TodoItems.Update(item);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
