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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserName).IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.EmailAddress).IsRequired();
            builder.HasMany(x => x.Forms).WithOne(f => f.Users).HasForeignKey(a => a.UsersID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ClaimUser).WithOne(b => b.User).HasForeignKey(b => b.UserID).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
