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
    public class FormTypeConfiguration : IEntityTypeConfiguration<FormType>

    {
        public void Configure(EntityTypeBuilder<FormType> builder)
        {
            builder.ToTable("FormType");
            builder.HasKey(a => a.TypeID);
            builder.Property(a => a.TypeName).IsRequired();
            builder.HasMany(a => a.Forms).WithOne(a => a.FormType).HasForeignKey(a => a.TypeID).OnDelete(DeleteBehavior.NoAction);
      
        }
    }
}
