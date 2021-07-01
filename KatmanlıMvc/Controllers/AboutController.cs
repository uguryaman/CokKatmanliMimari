using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var value = am.GEtlist();
            return View(value);
        }
        [HttpGet]
        public ActionResult AboutAdd()
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult AboutAdd(About p)
        {
            am.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EditAbout(int id)
        {
            var value = am.GetById(id);
            if (value.AboutStatus==true)
            {
                value.AboutStatus = false;
            }
            else
            {
                value.AboutStatus = true;
            }
            am.AboutUpdate(value);
            return RedirectToAction("Index");
        }
    }
}