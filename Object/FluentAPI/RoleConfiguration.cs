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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(a => a.RoleID);
            builder.Property(a => a.RoleName).IsRequired();
            builder.HasMany(a => a.Users).WithOne(b => b.Roles).HasForeignKey(b => b.RoleID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
