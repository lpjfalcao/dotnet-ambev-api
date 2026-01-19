using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
