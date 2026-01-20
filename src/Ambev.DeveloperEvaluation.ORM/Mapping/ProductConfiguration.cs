using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = new Guid("d1f4bd52-4aea-4a1f-8fda-aa897a77bcac"),
                Name = "Mouse sem fio Logi",
                Description = "Mouse em fio Logi com entrada USB",
            },
            new Product
            {
                Id = new Guid("be957b3a-d67a-4402-8ca0-9c59d42a25c9"),
                Name = "Mouse + Teclado sem fio USB Microsoft",
                Description = "DocksStation para PC",
            });
        }
    }
}
