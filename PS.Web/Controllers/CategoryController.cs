using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ps.Domain.Entities;
using PS.Service.Services_withpatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(categoryService.GetAll());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                categoryService.Add(category);
                categoryService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {

           if (id != null)
            {
                Category c = categoryService.GetById(id);
                return View(c);
            }
            return NotFound();
            
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category c)
        {
            try
            {
                c.CategoryId = id;
                categoryService.Update(c);
                categoryService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
