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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryvalues = cm.GetCategoryList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categorValidator = new CategoryValidator();
            ValidationResult result = categorValidator.Validate(category);
            if (result.IsValid)
            {
                cm.CategoryAddBL(category);
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

        public ActionResult DeleteCategory(int id)
        {
            var category = cm.GetByID(id);
            cm.CategoryDeleteBL(category);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = cm.GetByID(id);  
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdateBL(category);
            return RedirectToAction("Index");
        }
    }
}