using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.DataAccess;

var host = Host.CreateDefaultBuilder(args).ConfigureServices(
    services =>
    {
        services.AddSingleton<IDataAccess, DataAccess>();
    }
    ).Build();


var app = host.Services.GetRequiredService<IDataAccess>();

IEnumerable<dynamic> result = app.GetAll();

await host.RunAsync();