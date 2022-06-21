using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ps.Domain.Entities
{
    public enum PackagingType
    {
        [Display(Name = "Carton")]
        Carton = 0,
        [Display(Name = "Plastic")]
        Plastic = 1
    }
    public  class Product
    {
        public PackagingType PackagingType { get; set; } //enum
        public int ProductId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Production Date")]
        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage ="This field is required !")]
        [StringLength(25,ErrorMessage ="User input max 25 !")]
        [MaxLength(50,ErrorMessage =" Storage max 50 !")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        public  string ImageUrl2 { get; set; }
        [Display(Name="Category")]
        public int? CategoryFK { get; set; } // ? : nullable

        //Prop de navigation
        [ForeignKey("CategoryFK")]
        public virtual Category Category { get; set; }
        public virtual IList<Provider> Providers { get; set; }
        public virtual IList<Facture> Factures { get; set; }

        public override string ToString()
        {
            return "name = "+Name+" , Quantity = "+Quantity;
        }
        public virtual string GetMyType()
        {
            return "UNKNOWN";
        }
    }
}
