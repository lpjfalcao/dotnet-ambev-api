using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder
{
    public class UpdateOrderRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateOnly OrderDate { get; set; }
        public bool IsCancelled { get; set; }

        public IEnumerable<UpdateOrderItemRequest> OrderItems { get; set; } = [];
    }

    public class UpdateOrderItemRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
