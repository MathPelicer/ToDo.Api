using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Models;

namespace ToDo.Api.Interfaces
{
    public interface ITodoService
    {
        public Task<IEnumerable<TodoItem>> GetTodoItems();

        public Task<TodoItem> GetTodoItem(Guid id);

        public Task<IActionResult> PutTodoItem(Guid id, TodoItem todoItem);
    }
}
