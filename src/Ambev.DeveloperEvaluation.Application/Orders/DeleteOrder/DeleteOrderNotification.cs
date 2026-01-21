using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder
{
    public class DeleteOrderNotification : INotification
    {
        public string Message { get; set; } = null!;
    }
}
