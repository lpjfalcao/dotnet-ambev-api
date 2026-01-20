using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateOnly OrderDate { get; set; }
        public bool IsCancelled { get; set; }

        public IEnumerable<CreateOrderItemCommand> OrderItems { get; set; } = [];
    }

    public class CreateOrderItemCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
