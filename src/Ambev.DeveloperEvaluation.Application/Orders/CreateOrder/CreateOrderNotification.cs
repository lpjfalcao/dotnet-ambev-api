using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderNotification : INotification
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Branch { get; set; }
        public bool IsCancelled { get; set; }
    }
}
