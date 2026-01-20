using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderNotificationHandler : INotificationHandler<CreateOrderNotification>
    {
        private readonly ILogger<CreateOrderNotificationHandler> _logger;

        public CreateOrderNotificationHandler(ILogger<CreateOrderNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CreateOrderNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Nova venda cadastrada...");
            _logger.LogInformation($"Id: {notification.Id}");
            _logger.LogInformation($"Cliente:{notification.CustomerName}");
            _logger.LogInformation($"Data da venda: {notification.OrderDate}");
            _logger.LogInformation($"Total: {notification.TotalAmount.ToString("C")}");
            _logger.LogInformation($"Filial: {notification.Branch}");

            return Task.CompletedTask;
        }
    }
}
