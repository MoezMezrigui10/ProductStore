using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ps.Domain.Entities;
using PS.Service.Services_withpatterns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;
        ICategoryService categoryService;
        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public ActionResult Index2()
        {
            return View(productService.GetAll()); ;
        }
        // GET: ProductController
        public ActionResult Index(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
                return View(productService.GetMany(p=>p.Name.Contains(filter)));
            return View(productService.GetAll());
            //return View(productService.GetAll().OrderByDescending(p=>p.Price));
            //return View(productService.GetMany(p=>p.Name.Contains("a")));
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (id != null)
             return View(productService.GetById(id));
            return NotFound();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.mycategories = new SelectList(categoryService.GetAll(), "CategoryId", "Name");
            
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product,IFormFile file)
        {
            try
            {
                // ajout du produit à la base
                product.ImageUrl2 = file.FileName; // maj du nom de l'image dans la base
                productService.Add(product);
                productService.Commit();


                // ajout de l'image dans le dossier "uploads"
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id != null)
            {
                Product p = productService.GetById(id);
                ViewBag.mycategories = new SelectList(categoryService.GetAll(), "CategoryId", "Name",p.Category.Name);
                return View(p);
            }
            return NotFound();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product p)
        {
            try
            {
                p.ProductId = id;
                productService.Update(p);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            if (productService.GetById(id) == null)
            {
                return NotFound();
            }
            return View(productService.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Product p)
        {
            try
            {
                p = productService.GetById(id);
                productService.Delete(p);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
