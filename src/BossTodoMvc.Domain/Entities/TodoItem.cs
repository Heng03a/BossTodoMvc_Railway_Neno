namespace BossTodoMvc.Domain.Entities;

public class TodoItem
{
    public int Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public bool IsCompleted { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // Required by EF Core
    private TodoItem() { }

    public TodoItem(string title)
    {
        Title = title;
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }

    // Business rule: toggle completion state
    public void ToggleComplete()
    {
        IsCompleted = !IsCompleted;
    }

    public void UpdateTitle(string title)
{
    if (string.IsNullOrWhiteSpace(title))
        return;

    Title = title;
}

}
