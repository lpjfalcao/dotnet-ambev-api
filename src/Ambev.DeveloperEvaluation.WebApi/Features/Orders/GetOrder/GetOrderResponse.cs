using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder
{
    public class GetOrderResponse
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public CustomerResponse Customer { get; set; } = null!;
        public BranchResponse Branch { get; set; } = null!;
        public IEnumerable<OrderItemResponse> OrderItems { get; set; } = [];

    }

    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class BranchResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }

    public class OrderItemResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        [NotMapped]
        public decimal TotalAmount { get; set; }

        public Guid OrderId { get; set; }
    }
}
