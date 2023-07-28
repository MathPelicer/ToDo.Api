using Microsoft.EntityFrameworkCore;
using ToDo.Api.Models;

namespace ToDo.Api.Contexts
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
