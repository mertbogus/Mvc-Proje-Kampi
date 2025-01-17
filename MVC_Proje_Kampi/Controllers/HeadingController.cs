using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MVC_Proje_Kampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult IndexByCalender()
        {
            return View(new HeadingByCalendar());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new HeadingByCalendar();
            var events = new List<HeadingByCalendar>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in hm.GetList())
            {
                events.Add(new HeadingByCalendar()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }
            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingReport()
        {
            var result = hm.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = new List<SelectListItem>(from x in cm.GetCategoryList()
                                                                          select new SelectListItem
                                                                          {
                                                                              Text = x.CategoryName,
                                                                              Value = x.CategoryId.ToString()
                                                                          }).ToList();
            ViewBag.vlc=valuecategory;

            List<SelectListItem> valuewriter = (from x in wm.GetListBL()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlw = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBL(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueWriter = (from x in wm.GetListBL()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterName+""+x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.writerVlc = valueWriter;

            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;

            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdateBL(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            hm.HeadingDeleteBL(headingValue);
            return RedirectToAction("Index");
        }

    }
}