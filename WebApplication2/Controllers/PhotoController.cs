using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class PhotoController : Controller
    {

        private Manager m = new Manager();


        [Route("photo/{id}")]
        public ActionResult Details(int? id)
        {
            // this function for some reason isn't getting called. 
            var o = m.ProductPhotoGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
             
                return File(o.Photo, o.PhotoContentType);
            }
        }

        
     
    }
}
