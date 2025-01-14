using System.Collections.Generic;
using ToDoList.Models;

namespace TodoApp.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Add(TodoItem item);
        void Update(TodoItem item);
        void Delete(int id);
        void Save();
    }
}
