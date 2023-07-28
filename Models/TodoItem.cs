namespace ToDo.Api.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool isComplete { get; set; }
    }
}
