using ASP_NET_22._ToDo_WebApi_For_Unit_Test.Data;

namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.HostedServices;

public class DatabaseClearJob : IHostedService
{
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public DatabaseClearJob(ILogger<DatabaseClearJob> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    private bool _run;

    private async Task Run()
    {
        while (_run)
        {
            var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
            await Task.Delay(TimeSpan.FromSeconds(30));
            _logger.LogError("Transaction Processor Service is running");
            _logger.LogCritical($"Todos count = {dbContext.ToDoItems.Count()}");
        }
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _run = true;
        Run();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _run = false;
        return Task.CompletedTask;
    }
}
