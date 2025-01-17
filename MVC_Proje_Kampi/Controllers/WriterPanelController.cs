using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVC_Proje_Kampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        Context c = new Context();
        int id;

        public ActionResult WriterProfile()
        {
            string result = (string)Session["Mail"];
            var writerIdInfo = c.Writers.Where(w => w.Mail == result).Select(x => x.WriterId).FirstOrDefault();
            var writerValue = _writerManager.GetById(writerIdInfo);
            ViewBag.d = writerIdInfo;
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                _writerManager.WriterUpdateBL(writer);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["Mail"];
            var writeridinfo = c.Writers.Where(x => x.Mail == p).Select(x => x.WriterId).FirstOrDefault();
            
            var headings = hm.GetListByWriter(writeridinfo);
            return View(headings);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valuecategory = new List<SelectListItem>(from x in cm.GetCategoryList()
                                                                          select new SelectListItem
                                                                          {
                                                                              Text = x.CategoryName,
                                                                              Value = x.CategoryId.ToString()
                                                                          }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["Mail"];
            var writeridinfo = c.Writers.Where(x => x.Mail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.d = writeridinfo;
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writeridinfo;
            hm.HeadingAddBL(heading);
            return RedirectToAction("MyHeading");
            
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {

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
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDeleteBL(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int pages=1)
        {
            var headings = hm.GetList().ToPagedList(pages, 5);
            return View(headings);
        }
    }
}