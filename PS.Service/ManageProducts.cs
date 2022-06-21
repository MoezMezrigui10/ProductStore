using Ps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Service
{
    public class ManageProducts
    {
        IList<Product> products = new List<Product>();
        //ctor +2tab
        public ManageProducts( IList<Product> myproducts)
        {
            products = myproducts;

        }

        public IList<Product> Get5Chemicals(double price)
        {

            /*var query = from p in products
                        where p.Price > price && p is Chemical
                        select p;
            return query.Take(5).ToList();*/
            return products.Where(p => p.Price > price && p is Chemical).Take(5).ToList();
        }

        public IList<Product> GetProductsByPrice(double price)
        {

            /* var query = from p in products
                         where p.Price > price 
                         select p;
             return query.Skip(2).ToList();*/

            return products.Where(p => p.Price > price).Skip(2).ToList();
                }

         public double GetAveragePrice()
        {
            /*  var query = from p in products

                          select p.Price;

              return query.Average();*/

            return products.Average(p => p.Price);
        }

        public double GetMaxPrice()
        {
            //linq
            /*  var query = from p in products

                          select p.Price;

              return query.Max();*/
            //lambda
            return products.Max(p => p.Price);
        }

        public int GetCountProduct(string city)
        {
            /*var query = from c in products.OfType<Chemical>()
                        where c.City == city 
                        select c;
            return query.Count();*/

            //return products.OfType<Chemical>().Where(p => p.City == city).Count();
            return products.OfType<Chemical>().Count(p => p.Address.City == city);
        }
        public IList<Chemical> GetChemicalCity()
        {

            /* var query = from p in products.OfType<Chemical>()
                         orderby p.City
                         select p;


             return query.ToList();*/

            return products.OfType<Chemical>().OrderBy(p => p.Address.City).ToList();

        }

        public IList<Chemical> GetgroupChemicalCity()
        {
            // methode 1
            /* var query = from p in products.OfType<Chemical>()
                         orderby p.City
                         group p by p.City;
                  return (IList<Chemical>)query.ToList();*/
            /*var query = from p in products.OfType<Chemical>()
                        orderby p.City
                        select p;*/
          return (IList<Chemical>)products.OfType<Chemical>().OrderBy(p => p.Address.City).GroupBy(p => p.Address.City).ToList();
        }

        public IEnumerable<IGrouping<string,Chemical>> GetChemicalByCity2()
        {
           // return from p in products.OfType<Chemical>()
              //     orderby p.City
                //   group p by p.City;
            return products.OfType<Chemical>().OrderBy(p => p.Address.City).GroupBy(p => p.Address.City);
        }

        public void DisplayChemicalByCity()
        {
            var result= 
            products.OfType<Chemical>().OrderBy(p => p.Address.City).GroupBy(p => p.Address.City);
            foreach (var productByCity in result)
            {
                Console.WriteLine(" city = "+productByCity.Key);
                foreach (Chemical c in productByCity)
                {
                    Console.WriteLine("product = "+c.ToString());
                }
            }
        }
    }


}
