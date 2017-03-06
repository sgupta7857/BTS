using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform ; 


namespace WebApplication2.Controllers
{
    public class ProductAddform
    {
        public ProductAddform()
        {
        }
        [Required, StringLength(100)]

        public string ProductName { get; set; }
        public double Price { get; set; }
        [Required, StringLength(100)]

        public string ProductDesc { get; set; }
        public DateTime DateAdded
        {
            set
            {
                DateAdded = DateTime.Now;
            }

        }
        [Display(Name = "Product Photo")]
        [DataType(DataType.Upload)]
        public string PhotoUpload { get; set; }

    }
    public class ProductAdd
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductDesc { get; set; }
        public DateTime DateAdded
        {
            set
            {
                DateAdded = DateTime.Now;
            }

        }
        // Attention - 3 - In this "Add" class, notice the type is HttpPostedFileBase
        public  HttpPostedFileBase PhotoUpload { get; set; }

    }
    
    public class ProductBase
    {
        [Key]

        public int ProductID { get; set; }
        [Display(Name = "Product Photo")]
        [DataType(DataType.Upload)]
        public string PhotoUrl
        {
            get
            {
                return $"/photo/{ProductID}";
                //  return string.Format("{0}/photo/{id"); 
                                                    //  return $"/photo/{id} ; 
            }
        }
        public string ProductName { get; set; }
        public double Price { get; set; }
        [Required, StringLength(100)]

        public string ProductDesc { get; set; }
        public DateTime DateAdded
        {
            set
            {
                DateAdded = DateTime.Now;
            }



        }
        /*
        public string PhotoContentType { get; set; }
        public byte[] Photo { get; set; }
        */
    }
    public class ProductPhoto
    {
        public int ProductID { get; set; }
        public string PhotoContentType { get; set; }
        public byte[] Photo { get; set; }
    }
}