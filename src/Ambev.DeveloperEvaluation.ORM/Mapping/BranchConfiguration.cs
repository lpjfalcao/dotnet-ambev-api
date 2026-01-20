using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Location).IsRequired();

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Branch> builder)
        {
            builder.HasData(new Branch
            {
                Id = new Guid("f5af91f8-a4ef-4626-8828-928d852cf3f7"),
                Location = "Rio de Janeiro",
                Name = "Filial ABC"
            });
        }
    }
}
