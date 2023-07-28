using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Contexts;
using ToDo.Api.Interfaces;
using ToDo.Api.Models;

namespace ToDo.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            if (_context.TodoItems == null)
            {
                return Enumerable.Empty<TodoItem>();
            }
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItem(Guid id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task PutTodoItem(Guid id, TodoItem todoItem)
        {
            if(todoItem.Id != id)
            {
                return;
            }
        }
    }
}
