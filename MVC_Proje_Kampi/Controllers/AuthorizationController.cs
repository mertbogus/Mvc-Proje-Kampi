using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        RoleManager rm = new RoleManager(new EfRoleDal());

        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var admins = am.GetList();
            return View(admins);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            p.AdminPassword= Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(p.AdminPassword)));
            am.AdminAdd(p);
            return RedirectToAction("Index", "Authorization");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueadminrole = (from c in rm.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;
            var adminvalue = am.GetById(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var result = am.GetById(id);
            if (result.AdminStatus == true)
            {
                result.AdminStatus = false;
            }
            else
            {
                result.AdminStatus = true;
            }
            am.AdminUpdate(result);
            return RedirectToAction("Index");
        }
    }
}