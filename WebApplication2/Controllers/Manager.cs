using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        public Manager()
        {
            // If necessary, add constructor code here
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

        // ############################################################
        // Employee

        public IEnumerable<ProductBase> ProductGetAll()
        {
            return Mapper.Map<IEnumerable<ProductBase>>(ds.Products);
        }
        public ProductBase ProductAdd(ProductAdd newItem)
        {
            // Attempt to add the new item
            // Notice how we map the incoming data to the design model object
            var addedItem = ds.Products.Add(Mapper.Map<Product>(newItem));



            byte[] photoBytes = new byte[newItem.PhotoUpload.ContentLength];
            newItem.PhotoUpload.InputStream.Read(photoBytes, 0, newItem.PhotoUpload.ContentLength);

            // Then, configure the new object's properties
            addedItem.Photo = photoBytes;
            addedItem.PhotoContentType = newItem.PhotoUpload.ContentType;
           
            ds.SaveChanges();

            // If successful, return the added item, mapped to a view model object
            return (addedItem == null) ? null : Mapper.Map<ProductBase>(addedItem);
        }
        public ProductBase ProductGetById(int id)
        {
            var o = ds.Products.Find(id);
            return (o == null) ? null : Mapper.Map<ProductBase>(o); 
        }
        public ProductPhoto ProductPhotoGetById(int id)
        {
            var o = ds.Products.Find(id);
            return (o == null) ? null : Mapper.Map<ProductPhoto>(o); 
        }

        public bool ProductDelete(int? id)
        {
            var itemtodelete = ds.Products.Find(id);
            if (itemtodelete == null)
            {
                return false; 
            }
            else
            {
                ds.Products.Remove(itemtodelete);
                ds.SaveChanges();
                return true; 
            }
        }

      
    }
}