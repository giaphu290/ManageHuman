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
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
            builder.HasKey(a => a.PositionID);
            builder.Property(a => a.NameOfPosition).IsRequired();      
            builder.HasMany(x => x.UserPositions).WithOne(b => b.Position).HasForeignKey(b => b.PositionID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
