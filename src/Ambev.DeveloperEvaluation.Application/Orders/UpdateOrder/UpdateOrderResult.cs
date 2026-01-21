namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderResult
    {
        public Guid Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public IEnumerable<UpdateOrderItemResult> OrderItems { get; set; } = [];
    }

    public class UpdateOrderItemResult
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
