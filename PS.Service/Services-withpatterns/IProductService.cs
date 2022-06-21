using Ps.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service.Services_withpatterns
{
    public interface IProductService:IService<Product>
    {
        public IList<Product> FindMost5ExpensiveProds();
        public float UnavailableProductsPercentage();
        public IEnumerable<Product> GetProdsByClient(Client c);
    }
}
