namespace TodoList.DataAccess.Models;

public class TodoItemForInsert
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? CompleteByDate { get; set; }

}