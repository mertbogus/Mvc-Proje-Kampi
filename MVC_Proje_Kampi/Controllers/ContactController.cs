using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kampi.Controllers
{
    public class ContactController : Controller
    {
        //private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        ContactManager cm=new ContactManager(new EfContactDal());
        ContactValidator cv=new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetContactList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
           var contacts=cm.GetByID(id);
           return View(contacts);
        }

        public PartialViewResult ContactSideBarPartial()
        {
            string userEmail = (string)Session["WriterMail"];
            var contactList = cm.GetContactList();
            ViewBag.contactCount = contactList.Count();
            //var list = messageManager.GetMessageList(userEmail);
            //var sendList = list.FindAll(x => x.isDraft == false);
            //ViewBag.sendCount = sendList.Count();
            //var list2 = messageManager.GetListInbox(userEmail);
            //ViewBag.inboxCount = list2.Count();
            //var drafList = list.FindAll(x => x.isDraft == true);
            //ViewBag.draftCount = drafList.Count();
            return PartialView();
        }
    }
}