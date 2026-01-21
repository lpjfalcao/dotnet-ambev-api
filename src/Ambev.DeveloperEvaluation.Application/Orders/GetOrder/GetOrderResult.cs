using Ambev.DeveloperEvaluation.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder
{
    public class GetOrderResult
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public CustomerResult Customer { get; set; } = null!;
        public BranchResult Branch { get; set; } = null!;
        public IEnumerable<GetOrderItemResult> OrderItems { get; set; } = [];
    }

    public class CustomerResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class BranchResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }

    public class GetOrderItemResult
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
