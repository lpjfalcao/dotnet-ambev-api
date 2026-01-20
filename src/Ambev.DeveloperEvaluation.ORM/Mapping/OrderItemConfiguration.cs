using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.Discount).HasDefaultValue(0);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasData(new OrderItem
            {
                Id = new Guid("c1c0c125-8dce-4e65-b59b-674fab4e7645"),
                OrderId = new Guid("5a7f0c01-2658-4f83-8dc1-f58cd207d0c6"),
                ProductId = new Guid("d1f4bd52-4aea-4a1f-8fda-aa897a77bcac"),
                Quantity = 5,
                UnitPrice = 100M,
                Discount = 0.1M,
                TotalAmount = 450,
            },
            new OrderItem
            {
                Id = new Guid("4d1a70c9-1e3b-4878-aaef-8c802085728f"),
                OrderId = new Guid("5a7f0c01-2658-4f83-8dc1-f58cd207d0c6"),
                ProductId = new Guid("be957b3a-d67a-4402-8ca0-9c59d42a25c9"),
                Quantity = 10,
                UnitPrice = 100M,
                Discount = 0.2M,
                TotalAmount = 800
            });
        }
    }
}
