var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var todos = new List<string> { "Buy groceries", "Learn Docker" };

app.MapGet("/todos", () => todos);

app.MapPost("/todos", (string todo) => {
    todos.Add(todo);
    return Results.Created($"/todos", todo);
});

app.MapDelete("/todos/{index}", (int index) => {
    if (index < 0 || index >= todos.Count)
        return Results.NotFound();
    todos.RemoveAt(index);
    return Results.Ok();
});

app.Run();