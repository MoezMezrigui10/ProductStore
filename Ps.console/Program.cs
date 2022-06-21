using Microsoft.Extensions.DependencyInjection;
using Ps.Domain.Entities;
using PS.Data.Infrastructures;
using PS.Service;
using PS.Service.Services_withpatterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ps.console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region tp1
            //Console.WriteLine("Hello World!");
            ////creation d'une catégorie via le constructeur par défaut
            //Category c = new Category();
            //c.CategoryId = 1;
            //c.Name = "Food";
            //Category c2 = new Category(1, "nom");
            ////creation d'une catégorie vie l'initialiseur d'objet
            //Category c3 = new Category() { Name = "amine", CategoryId = 3 };
            //System.Console.WriteLine(c.GETDetails());
            //System.Console.WriteLine(c2.GetDetails2());
            //System.Console.WriteLine(c3.GetDetails2());
            //Provider p = new Provider
            //{
            //    Id = 1,
            //    Email = "Slama.monatasar@esprit.tn",
            //    UserName = "monta",
            //    Password = "123",
            //    ConfirmPassword = "123",
            //    Datecreated = DateTime.Now,
            //    IsApproved = true

            //};
            //Provider p1 = new Provider
            //{
            //    Id = 1,
            //    Email = "amine.boj@esprit.tn",
            //    UserName = "boj",
            //    Password = "123",
            //    ConfirmPassword = "234",
            //    Datecreated = DateTime.Now,
            //    IsApproved = false

            //};
            //p.SetIsApproved(p);
            //p1.SetIsApproved(p1);
            //System.Console.WriteLine("monta" + p.IsApproved);
            //System.Console.WriteLine("amine" + p1.IsApproved);
            //System.Console.WriteLine("amine" + p.SetIsApproved("123","123"));
            //System.Console.WriteLine("amine" + p1.SetIsApproved("123","245"));
            #endregion
            #region tp2
            /*
            Provider p2 = new Provider
            {
                Id = 1,
                Email = "amine.boj@esprit.tn",
                UserName = "boj",
                Password = "123",
                ConfirmPassword = "234",
                Datecreated = DateTime.Now,
                IsApproved = false,
                Products = new List<Product>()
                {
                    new Product
                    {
                        Name="myprod",Description="niceprod"
                        
                    }

                }


            };
            Console.WriteLine(p2.GETDetails());
            IList<Product> listproduct = new List<Product>()
            {
                 new Product()
                 {
                     Price=50,Name="myProd"
                 },
                 new Product()
                 {
                     Price=100,Name="myProd2"
                 },
                 new Chemical()
                 {
                     Price=85,Name="myProd3",City="ariana"
                 },
                 new Chemical()
                 {
                     Price=85,Name="myProd3",City="Benarous"
                 }

            };
            ManageProducts manageProduct = new ManageProducts(listproduct);
            Console.WriteLine("AveragePrice = : " + manageProduct.GetAveragePrice());
            foreach (Chemical c in manageProduct.Get5Chemicals(10))
            {
                Console.WriteLine("Name = " + c.Name+"\t Price =  " + c.Price);
            }
            //test methode display
            manageProduct.DisplayChemicalByCity();
            Console.WriteLine("le nbre total de produit by city = " +manageProduct.GetCountProduct("ariana"));
            // test methode getchemicalbycity2
            IEnumerable<IGrouping<string,Chemical>> result = manageProduct.GetChemicalByCity2();
            Console.WriteLine("++++++++++++++++++++++++++++++++");
            foreach (var chemicalByCity in result)
            {
                Console.WriteLine(chemicalByCity.Key);
                foreach (Chemical c in chemicalByCity)
                {
                    Console.WriteLine(c.ToString());
                }
            }
           
            

            
            

            */
            #endregion tp2
            #region Génération BDD
            /*PSContext context = new PSContext();
            Product product = new Product() { 
            Name="MyProd",Price=10,Description="NiceProd",ImageUrl2="Exemple.png"
            };
            context.Products.Add(product);//ajouter l'objet produit dans Dbset correspendant
            context.SaveChanges();//synchronisation entre dbset et la base*/
            #endregion
            #region Services
            /*ICategoryService categoryService = new CategoryService();
            categoryService.Add(new Category { Name="Sports"});
            categoryService.Add(new Category { Name = "Sports2" });*/
            #endregion
            #region With patterns
            //Category c = new Category { Name="sports"};
            //Category c2 = new Category { Name = "cosmétique" };
            //ICategoryService categoryService = new CategoryService();
            
            //categoryService.Add(c);
            //categoryService.Add(c2);
            //categoryService.Delete(c2);
            //categoryService.Commit();

            #endregion
            #region avec injection des dep

            //setup our DI
            var serviceProvider = new ServiceCollection()
             .AddScoped<ICategoryService, CategoryService>()
             .AddTransient<IUnitOfWork, UnitOfWork>()
             .AddSingleton<IDataBaseFactory, DataBaseFactory>()
             .BuildServiceProvider();
            //do the actual work here
            var serviceCategory = serviceProvider.GetService<ICategoryService>();
            serviceCategory.Add(new Category() { Name = "Cat1" });
            
            serviceCategory.Commit();

            #endregion
            Console.WriteLine("fin");
            Console.ReadKey();
        }


    }
}
