namespace TodoList.DataAccess.Models;

public class TodoItem
{
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? CompleteByDate { get; set; }
    public DateTime? CompletedDateTime { get; set; }
    public bool? IsCompleted { get; set; }
}
