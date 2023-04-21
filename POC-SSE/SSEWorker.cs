using Lib.AspNetCore.ServerSentEvents;
using System.Security.Cryptography;

public class SSEWorker : BackgroundService
{
    private readonly IServerSentEventsService _SseService;

    public SSEWorker(IServerSentEventsService sseService)
    {
        _SseService = sseService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);

                var clients = _SseService.GetClients();
                if (clients.Any())
                {
                    var number = RandomNumberGenerator.GetInt32(0, 100);
                    await _SseService.SendEventAsync(new ServerSentEvent
                    {
                        Id = "idEvento",
                        Type = "NomeEvento",
                        Data = new List<string> { number.ToString() }
                    },
                    stoppingToken);
                    Console.WriteLine($"Mensagem SSE com número {number} enviada!");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}