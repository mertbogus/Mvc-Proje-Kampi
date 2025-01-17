using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            p = (string)Session["Mail"];
            var writeridinfo = c.Writers.Where(x => x.Mail == p).Select(y=>y.WriterId).FirstOrDefault();
            var contents = cm.GetListByWriter(writeridinfo);
            return View(contents);
            
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
              ViewBag.d = id;
              return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["Mail"];
            var writeridinfo = c.Writers.Where(x => x.Mail == mail).Select(y => y.WriterId).FirstOrDefault();
            p.ContentDate = DateTime.Parse( DateTime.Now.ToLongDateString());
            p.WriterId = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAddBL(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}