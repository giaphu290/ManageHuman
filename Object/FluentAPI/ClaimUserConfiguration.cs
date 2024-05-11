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
    public class ClaimUserConfiguration : IEntityTypeConfiguration<ClaimUser>
    {
        public void Configure(EntityTypeBuilder<ClaimUser> builder)
        {
            builder.ToTable("ClaimUser");
            builder.HasKey(x => x.Id);
            //builder.HasOne(x => x.User).WithMany(b => b.ClaimUser).HasForeignKey(x => x.UsersID);
            //builder.HasOne(x => x.Claim).WithMany(b => b.ClaimUser).HasForeignKey(x => x.ClaimID);

        }
    }
}
