namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder
{
    public class UpdateOrderResponse
    {
        public Guid Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public IEnumerable<UpdateOrderItemResponse> OrderItems { get; set; } = [];
    }

    public class UpdateOrderItemResponse
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount => CalculateTotalAmount();

        private decimal CalculateTotalAmount()
        {
            return (UnitPrice * Quantity) - Discount;
        }
    }
}
