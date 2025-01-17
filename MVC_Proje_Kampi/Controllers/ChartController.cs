using DataAccessLayer.Concrete;
using MVC_Proje_Kampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        // GET: Chart
        private Context _context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 8
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 4
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Film",
                CategoryCount = 9
            });
            return categoryClasses;
        }

        public ActionResult CategoryPieChart()
        {
            return View();
        }
        public ActionResult CategoryColumnChart()
        {
            return View();
        }
        public ActionResult CategoryLineChart()
        {
            return View();
        }

        public List<CategoryClass> CategoryListChart()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            using (var _context = new Context())
            {
                categoryClasses = _context.Categories.Select(x => new CategoryClass
                {
                    CategoryName = x.CategoryName,
                    CategoryCount = x.CategoryName.Length
                }).ToList();
            }

            return categoryClasses;
        }

        public ActionResult VisualizeByCategory()
        {
            return Json(CategoryListChart(), JsonRequestBehavior.AllowGet);
        }
    }
}
