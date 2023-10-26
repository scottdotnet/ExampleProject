namespace ExampleProject.Shared.Todo.Models;

public sealed class TodoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
}
