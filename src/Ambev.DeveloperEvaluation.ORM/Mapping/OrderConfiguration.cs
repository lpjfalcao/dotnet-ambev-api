using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.OrderNumber).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.IsCancelled).IsRequired();

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new Order
            {
                Id = new Guid("5a7f0c01-2658-4f83-8dc1-f58cd207d0c6"),
                BranchId = new Guid("f5af91f8-a4ef-4626-8828-928d852cf3f7"),
                CustomerId = new Guid("9a5fef4b-58c9-4885-89b8-4ff99308e577"),
                OrderNumber = 1,
                OrderDate = new DateOnly(2026, 1, 20),
                TotalAmount = 1250M,
                IsCancelled = false

            });
        }
    }
}
