using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int ProductID{ get; set; }
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
        public Category Category { get; set; }
        public Review ReviewList { get; set; }
        public Manufacturer ManufacturerList { get; set; }
        public string PhotoContentType { get; set; }
        public byte[] Photo { get; set; }
    }
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public double rating { get; set; }
        public DateTime ReviewDate {
            set
            {
                ReviewDate = DateTime.Now; 
            }
        }
        public string ReviewText { get; set; } 
    }
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductID { get; set; }
    }
    public class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ProductId { get; set; }
   
        
    }
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public Boolean isShippingAddress { get; set; }
    }
}