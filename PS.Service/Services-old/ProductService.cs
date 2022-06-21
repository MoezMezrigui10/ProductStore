using Ps.Domain.Entities;
using PS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service.Services
{
    public class ProductService:IProductService
    {
        PSContext ctx = new PSContext();

        public void Add(Product p)
        {
            ctx.Products.Add(p);
            ctx.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return (IList<Product>)ctx.Products;
        }

        public void Remove(Product p)
        {
            ctx.Products.Remove(p);
            ctx.SaveChanges();
        }
    }
}
