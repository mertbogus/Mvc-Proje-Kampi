using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    [Authorize(Roles = "B")]
    public class İstatistikController : Controller
    {
        Context cm = new Context();
        public ActionResult Index()
        {
            var Totalcategory = cm.Categories.Count();
            var Categorysoftware = cm.Categories.Count(x => x.CategoryName == "Yazılım");
            var WriteraCount = cm.Writers.Count(x => x.WriterName.Contains("a"));
            var MaxtitleCategory = cm.Headings.Max(x => x.Category.CategoryName);
            var CategoryTrue = cm.Categories.Count(x => x.CategoryStatus == true);
            var CategoryFalse = cm.Categories.Count(x => x.CategoryStatus == false);


            ViewBag.Totalcategory = Totalcategory;
            ViewBag.Categorysoftware = Categorysoftware;
            ViewBag.WriteraCount = WriteraCount;
            ViewBag.MaxtitleCategory = MaxtitleCategory;
            ViewBag.Status = (CategoryTrue - CategoryFalse);
            
            return View();
        }
    }
}