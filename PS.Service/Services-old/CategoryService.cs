using Ps.Domain.Entities;
using PS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service.Services
{
    public class CategoryService : ICategoryService
    {
        PSContext context = new PSContext();
        public void Add(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
        }

        public IList<Category> GetAll()
        {
            return (IList<Category>)context.Categories;
        }

        public void Remove(int CategoryId)
        {
            Category c = context.Categories.Find(CategoryId);
            context.Categories.Remove(c);
            context.SaveChanges();
            //context.Categories.Remove(context.Categories.Find(CategoryId));
        }
    }
}
