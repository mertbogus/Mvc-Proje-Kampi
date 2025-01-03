using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator ValidationRules = new WriterValidator();
        public ActionResult Index()
        {
            var Writervalues = wm.GetListBL();
            return View(Writervalues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
             return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult result=ValidationRules.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterAddBL(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue=wm.GetById(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = ValidationRules.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterUpdateBL(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return View();
        }
    }
}