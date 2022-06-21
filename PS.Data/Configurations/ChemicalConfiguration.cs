using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            //1
            builder.OwnsOne(c => c.Address).Property(add => add.StreetAdress).
                HasMaxLength(50).HasColumnName("MyStreet");
            builder.OwnsOne(c => c.Address).Property(add => add.City).
                IsRequired().HasColumnName("MyCity");

            //2
            /*builder.OwnsOne(c => c.Address, myadd =>
            {
                myadd.Property(a => a.City).HasColumnName("MyCity").IsRequired();
                myadd.Property(a => a.StreetAdress).HasColumnName("MyStreet").HasMaxLength(50);
            });*/
        }
    }
}
