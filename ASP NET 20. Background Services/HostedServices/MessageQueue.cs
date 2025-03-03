using ASP_NET_20._Background_Services.Data;
using ASP_NET_20._Background_Services.DTOs;
using ASP_NET_20._Background_Services.Models;
using Microsoft.EntityFrameworkCore;


namespace ASP_NET_20._Background_Services.HostedServices;

public class MessageQueue
{
    //private readonly ConcurrentQueue<CreateTransactionRequest> _queue = new();
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public MessageQueue(IServiceProvider serviceProvider, ILogger<MessageQueue> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async void Enqueue(CreateTransactionRequest request)
    {
        //_queue.Enqueue(request);
        var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
        dbContext.Transactions.Add(new Transaction
        {
            Data = request.Data,
            Status = TransctionStatus.Created
        });
        await dbContext.SaveChangesAsync();
    }

    public async Task<Transaction> Dequeue()
    {
        //_queue.TryDequeue(out var request);
        var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
        var transaction = await dbContext.Transactions
                        .Where(t => t.Status == TransctionStatus.Created)
                        .OrderBy(t => t.Id)
                        .FirstOrDefaultAsync();
        transaction.Status = TransctionStatus.Processing;
        _logger.LogCritical($"Transaction Data {transaction.Data} - Transaction Status {transaction.Status}");
        await dbContext.SaveChangesAsync();
        return transaction;
    }

    public async Task Acknowlage(int id)
    {
        var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
        var transaction = await dbContext.Transactions
            .FirstOrDefaultAsync(t=> t.Status == TransctionStatus.Processing && t.Id == id);
        if (transaction is null) return;
        transaction.Status = TransctionStatus.Processed;
        _logger.LogCritical($"Transaction Data {transaction.Data} - Transaction Status {transaction.Status}");
        await dbContext.SaveChangesAsync();
    }

    public async Task Abort(int id)
    {
        var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
        var transaction = await dbContext.Transactions
            .FirstOrDefaultAsync(t => t.Status == TransctionStatus.Processing && t.Id == id);
        if (transaction is null) return;
        transaction.Status = TransctionStatus.Aborted;
        _logger.LogCritical($"Transaction Data {transaction.Data} - Transaction Status {transaction.Status}");
        await dbContext.SaveChangesAsync();
    }


}
