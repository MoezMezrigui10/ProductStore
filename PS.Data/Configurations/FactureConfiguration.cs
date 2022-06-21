using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configurations
{
    public class FactureConfiguration : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
            builder.HasKey(f => new
            {
                f.DateAchat,
                f.ClientFK, 
                f.ProductFK 
            });
        }
    }
}
