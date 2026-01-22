using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder
{
    public class CreateOrderRequest
    {
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateOnly OrderDate { get; set; }
        public bool? IsCancelled { get; set; }

        public IEnumerable<CreateOrderItemRequest> OrderItems { get; set; } = [];
    }
    public class CreateOrderItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
