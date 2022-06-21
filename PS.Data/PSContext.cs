using Microsoft.EntityFrameworkCore;
using Ps.Domain.Entities;
using PS.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data
{
   public class PSContext:DbContext
    {
        public PSContext()
        {
           // Database.EnsureCreated();
        }
        public DbSet<Chemical> chemicals { get; set; }
        public DbSet<Biological> biologicals { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=ProductStoreDB;
            Integrated Security=true;MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ChemicalConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FactureConfiguration());

            //Configurer toute les propriétés de type string et dont le nom commence par “Name”

            foreach (var property in modelBuilder.Model.GetEntityTypes().
                SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(string) && p.Name.StartsWith("Name")))
            {
                property.SetColumnName("MyName");
            }

            // TPH : Table per hierarchy

            modelBuilder.Entity<Product>().HasDiscriminator<int>("IsBiological")
                .HasValue<Product>(0)
                .HasValue<Biological>(1)
                .HasValue<Chemical>(2);

            //TPT : Table per type
            //modelBuilder.Entity<Biological>().ToTable("Biologicals");
            //modelBuilder.Entity<Chemical>().ToTable("Chemicals");


        }

    }
}
