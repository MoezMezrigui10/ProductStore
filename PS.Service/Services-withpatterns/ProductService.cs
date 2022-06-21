using Ps.Domain.Entities;
using PS.Data.Infrastructures;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PS.Service.Services_withpatterns
{
    public class ProductService:Service<Product>,IProductService
    {
        IUnitOfWork utk;
        public ProductService(IUnitOfWork utk):base(utk)
        {
            this.utk = utk;
        }
        public IList<Product> FindMost5ExpensiveProds()
        {
            return GetMany().OrderByDescending(p => p.Price).Take(5).ToList();
        }
        public float UnavailableProductsPercentage()
        {
            int nbUnavailable = (from p in GetMany(p => p.Quantity == 0)
                                 select p).Count();
            int nbProds = GetMany().Count();
            return ((float)nbUnavailable / nbProds) * 100;
        }
        public IEnumerable<Product> GetProdsByClient(Client c)
        {
            IFactureService sf = new FactureService(utk);
            var req = sf.GetMany(f => f.ClientFK == c.CIN)
            .ToList().Select(f => f.Product);
            return req;
        }
        public void DeleteOldProds()
        {
            var req = GetMany().Where(p => (DateTime.Now - p.DateProd).TotalDays > 365);
            foreach (Product p in req)
                Delete(p);
            Commit();
        }

        

        
    }
}
