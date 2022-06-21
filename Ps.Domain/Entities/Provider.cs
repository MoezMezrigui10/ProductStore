using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ps.Domain.Entities
{
  public  class Provider:Concept
    {
        //prop de base
        [Key] //(Id is already a primary key By Convention)
        public int Id { get; set; }
        [NotMapped] // ne figure pas dans la BDD
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        /*private string myconfirm;

        public string ConfirmPassword
        {
            get { return myconfirm; }

            set { if (value == Password)

                    myconfirm = value;
                else
                    Console.WriteLine("error");
            }
        }*/
        public DateTime Datecreated { get; set; }
        [Required]
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsApproved { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8),Required]
        public string Password { get; set; }
        /*private string Mypass;

        public string Password
        {
            get { return Mypass; }
            set {
                if (value.Length >= 5 && value.Length <= 20)
                    Mypass = value;
                else
                    Console.WriteLine("error");
            }
        }*/
        public string  UserName { get; set; }

        //prop de navigation
        public virtual IList<Product> Products { get; set; }


        //méthodes
        public void SetIsApproved(Provider p)
        {
            if (p.Password.Equals(p.ConfirmPassword))
                p.IsApproved = true;
            else p.IsApproved = false;
        }
        public bool SetIsApproved(string password, string confirmPassword)
        {
            if (password.Equals(confirmPassword))
                return true;
            else return false;
        }
        public override string GETDetails()
        {
            string result=  "userName : "+UserName+" , email : "+Email;
            foreach (Product p in Products)
            {
                result +="\n Name : " + p.Name + "Description : " + p.Description;
            }
            return result;
        }
        public void GetProducts(string filterType,string filterValue)
        {
            switch (filterType.ToLower()) {
                case "price":
                    foreach (Product p in Products)
                    {
                        if (p.Price == double.Parse(filterValue))
                        {
                            Console.WriteLine(" Name : "+ p.Name + "Desc : "+p.Description);
                        }
                        
                    }
                    break;
                case "dateprod":
                    foreach(Product p in Products)
                    {
                        if ( DateTime.Equals(filterValue,p.DateProd))
                        {

                            Console.WriteLine(" Name : " + p.Name + "Desc : " + p.Description);
                        }
                    }
                    break;
            }
        }
    }
}
