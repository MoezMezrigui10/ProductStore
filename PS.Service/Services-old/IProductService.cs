using Ps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service.Services
{
    public interface IProductService
    {
        public void Add(Product p);
        public void Remove(Product p);
        public IList<Product> GetAll();
    }
}
