using BusinessObject.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPI
{
    public class UserPositionConfiguration : IEntityTypeConfiguration<UserPosition>
    {
        public void Configure(EntityTypeBuilder<UserPosition> builder)
        {
            builder.ToTable("UserPosition");
            builder.HasKey(x => x.UserPositionId);
            builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.timestart).IsRequired();
            builder.Property(x => x.timeend).IsRequired();
            builder.Property(x => x.Paid).IsRequired();
            
         
        }
    }
}
