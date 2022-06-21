using Ps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service.Services
{
    public interface ICategoryService
    {
        public void Add(Category c);
        public void Remove(int CategoryId);
        public IList<Category> GetAll();
    }
}
