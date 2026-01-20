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
}
