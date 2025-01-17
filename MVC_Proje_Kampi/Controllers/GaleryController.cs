using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    
    public class GaleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        
        public ActionResult Index()
        {
            var images = ifm.GetImageList();
            return View(images);
        }
    }
}