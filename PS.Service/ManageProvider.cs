using Ps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Service
{
   public class ManageProvider
    {
     public List<Provider> GetProvidersByName(string name,List<Provider> providers)
        {

            //methode classique
            /* List<Provider> result = new List<Provider>();
             foreach (Provider p in providers)
             {
                 if (p.UserName.Contains(name))
                 {
                     result.Add(p);

                 }
             }
             return result;*/
            //linq
            var query = from p in providers
                        where p.UserName.Contains(name)
                        select p;
            return query.ToList();
        }
        public Provider GetFirstProvidersByName(string name, List<Provider> providers)
        {
            var query = from p in providers where p.UserName.StartsWith(name) select p;
            return query.FirstOrDefault();
        }
        public Provider GetProviderById(int id, List<Provider> providers)
        {
            var query = from p in providers where p.Id == id select p;
            return query.SingleOrDefault();
        }
    }
}
