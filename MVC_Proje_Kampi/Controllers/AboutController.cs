using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    [Authorize(Roles = "B")]
    public class AboutController : Controller
    {
        

        private AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var result = _aboutManager.GetAboutList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(About about)
        {
            _aboutManager.AboutAddBL(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}