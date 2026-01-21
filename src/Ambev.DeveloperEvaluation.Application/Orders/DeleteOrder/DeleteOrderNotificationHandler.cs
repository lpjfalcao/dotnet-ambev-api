using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder
{
    public class DeleteOrderNotificationHandler : INotificationHandler<DeleteOrderNotification>
    {
        private readonly ILogger<DeleteOrderNotificationHandler> _logger;

        public DeleteOrderNotificationHandler(ILogger<DeleteOrderNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DeleteOrderNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(notification.Message);

            return Task.CompletedTask;
        }
    }
}
