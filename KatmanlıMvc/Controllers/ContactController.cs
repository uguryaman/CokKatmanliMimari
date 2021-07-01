using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Index()
        {
            var value = cm.GEtlist();
            return View(value);
        }
        public ActionResult GetMessage(int id)
        {
            var value = cm.GetById(id);
            return View(value);
        }
    }
}