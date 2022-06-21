using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //many to many (product * -----* provider)
            builder.HasMany(prod => prod.Providers).
                WithMany(prov => prov.Products).
                UsingEntity(e=>e.ToTable("Providings"));

            //one to many (product 1-----* Category)
            builder.HasOne(p => p.Category).
                WithMany(c => c.Products).
                HasForeignKey(p => p.CategoryFK).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}
