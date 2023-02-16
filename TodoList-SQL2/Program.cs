using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.DataAccess;
using TodoList.DataAccess.Models;

var host = Host.CreateDefaultBuilder(args).ConfigureServices(
    services =>
    {
        services.AddSingleton<IDataAccess, DataAccess>();
    }
    ).Build();

var app = host.Services.GetRequiredService<IDataAccess>();

IEnumerable<TodoItem> results = app.GetAll();
foreach (var result in results)
{
    System.Console.WriteLine($"Title: {result.Title} \t Description: {result.Description}");
}

int v = app.CreateTodo();
System.Console.WriteLine($"Added {v} line/s.");

IEnumerable<TodoItem> results2 = app.GetAll();
foreach (var result in results2)
{
    System.Console.WriteLine($"Title: {result.Title} \t Description: {result.Description}");
}

System.Console.WriteLine("We're done here...");

await host.RunAsync();