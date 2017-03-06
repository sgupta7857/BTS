using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PagedList;
using PagedList.Mvc;


using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {

        private Manager m = new Manager();
        //
        // GET: /Product/
        public ActionResult Index(int page =1, int pageSize=10)
        {
            var x = m.ProductGetAll();
            PagedList<ProductBase> model = new PagedList<ProductBase>(x, page, pageSize);
            return View(model); 

        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int? id)
        {
            // o contains photourl -> which is suppose to get redirect to the 3rd pic.


            var o = m.ProductGetById(id.GetValueOrDefault()); 
            if(o==null)
            {
                return HttpNotFound(); 
            }
            else
            {
              
                return View(o); 
            }
        
        
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {

            var form = new ProductAddform();

            return View(form);
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(ProductAdd collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }
         
            collection.PhotoUpload = Request.Files["UploadedFile"]; 
            // Process the input
            var addedItem = m.ProductAdd(collection);


            if (addedItem == null)
            {
                return View(collection);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.ProductID });
            }
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemtodelete = m.ProductGetById(id.GetValueOrDefault());
            if (itemtodelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemtodelete);
            }
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int ?id, FormCollection collection)
        {
            var result = m.ProductDelete(id.GetValueOrDefault());
            return RedirectToAction("index"); 

        }
    }
}
