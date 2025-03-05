namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.HostedServices
{
    public class TransactionProcessorJob : IHostedService
    {
        private readonly ILogger _logger;
        private readonly MessageQueue _messageQueue;

        public TransactionProcessorJob(MessageQueue messageQueue, ILogger<TransactionProcessorJob> logger)
        {
            _messageQueue = messageQueue;
            _logger = logger;
        }

        private bool _run;

        private async Task Run()
        {
            while (_run)
            {
                var transaction = await _messageQueue.Dequeue();
                if (transaction is not null)
                {
                    _logger.LogCritical("Transaction {Data} Started!", transaction.Data);
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    //_logger.LogCritical("Transaction {Data} Finished!", transaction.Data);
                    await _messageQueue.Acknowlage(transaction.Id);
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
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
}
