using System;
using System.Collections.Generic;
using System.Text;

namespace Ps.Domain.Entities
{
   public class Category : Concept
    {
        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
        //ctor +double tab
        public Category()
        {

        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }

        public override string GETDetails()
        {
            return "Name"+Name+"categoryId"+CategoryId;
        }
        public override string GetDetails2()
        {
            return base.GetDetails2() + "this s from Category";
        }
    }
}
