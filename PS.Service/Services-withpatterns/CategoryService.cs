using Ps.Domain.Entities;
using PS.Data.Infrastructures;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service.Services_withpatterns
{
    public class CategoryService:Service<Category>,ICategoryService
    {
        public CategoryService(IUnitOfWork utk) :base(utk)
        {

        }

        //implémentation de tt les méthodes sauf CRUD
    }
}
