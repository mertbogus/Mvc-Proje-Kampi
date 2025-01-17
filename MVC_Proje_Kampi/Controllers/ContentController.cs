using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string searchedWord)
        {
            var searchedWords = cm.GetSearchedWords(searchedWord);
            if (!string.IsNullOrEmpty(searchedWord))
            {
                return View(searchedWords);
            }

            return View(cm.GetContentList());

            
        }

        public ActionResult ContentByHeading(int id)
        {
            var contents = cm.GetListByHeadingID(id);
            return View(contents);
        }
    }
}