using Microsoft.AspNetCore.Mvc;
using TodoApp.Repositories;
using ToDoList.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var todos = _repository.GetAll();
            return View(todos);
        }

        public IActionResult Form(int? id)
        {
            if (id.HasValue)
            {
                var todo = _repository.GetById(id.Value);
                if (todo == null)
                {
                    return NotFound();
                }
                return View(todo);
            }
            return View(new TodoItem());
        }

        [HttpPost]
        public IActionResult Save(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                {
                    _repository.Add(item);
                }
                else
                {
                    _repository.Update(item);
                }
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View("Form", item);
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
