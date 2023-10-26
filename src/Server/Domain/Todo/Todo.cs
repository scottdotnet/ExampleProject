namespace ExampleProject.Server.Domain.Todo;

public sealed class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
}
