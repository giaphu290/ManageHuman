using Entity.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.FluentAPI
{
    public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("Claim");
            builder.HasKey(a => a.ClaimID);
            builder.Property(a => a.ClaimType).IsRequired();
            builder.Property(a => a.ClaimValue).IsRequired();
            builder.HasMany(a => a.ClaimUser).WithOne(b => b.Claim).HasForeignKey(b => b.ClaimID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
