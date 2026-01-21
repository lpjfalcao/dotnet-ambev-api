using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderNotificationHandler : INotificationHandler<UpdateOrderNotification>
    {
        private readonly ILogger<UpdateOrderNotificationHandler> _logger;

        public UpdateOrderNotificationHandler(ILogger<UpdateOrderNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UpdateOrderNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Pedido atualizado...");
            _logger.LogInformation($"Id: {notification.Id}");
            _logger.LogInformation($"Cliente:{notification.CustomerName}");
            _logger.LogInformation($"Data da venda: {notification.OrderDate}");
            _logger.LogInformation($"Total: {notification.TotalAmount.ToString("C")}");
            _logger.LogInformation($"Filial: {notification.Branch}");

            return Task.CompletedTask;
        }
    }
}
