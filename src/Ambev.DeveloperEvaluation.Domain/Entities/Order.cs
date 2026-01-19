using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int OrderNumber { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
        public bool IsCancelled { get; set; }

        public void CalculateTotalAmout()
        {
            TotalAmount = OrderItems.Sum(x => x.TotalAmount);
        }
    }
}
