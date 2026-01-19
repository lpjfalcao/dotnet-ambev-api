using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}
