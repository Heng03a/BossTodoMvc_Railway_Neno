using BossTodoMvc.Domain.Entities;

namespace BossTodoMvc.Web.ViewModels;

public class TodoListViewModel
{
    public IEnumerable<TodoItem> Items { get; set; } = [];
    public string Status { get; set; } = "all";   // all | active | completed
    public string Sort { get; set; } = "newest";  // newest | oldest
}
