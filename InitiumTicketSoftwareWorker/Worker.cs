using InitiumTicketSoftwareEntity.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InitiumTicketSoftwareWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITicketService _ticketService;

        public Worker(ILogger<Worker> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Run(async () =>
                {
                    while(!stoppingToken.IsCancellationRequested)
                    {
                        await _ticketService.DeQueue(1).ConfigureAwait(true);

                        await Task.Delay(2000, stoppingToken).ConfigureAwait(true);
                    }
                });

                await Task.Run(async () =>
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        await _ticketService.DeQueue(2).ConfigureAwait(true);

                        await Task.Delay(3000, stoppingToken).ConfigureAwait(true);
                    }
                });
            }
        }
    }
}
