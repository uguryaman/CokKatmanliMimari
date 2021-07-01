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
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        AbilityManager am = new AbilityManager(new EfAbilityDal());
        public ActionResult Index()
        {
            var value = am.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSertifika(Ability ability)
        {
            am.AbilityAdd(ability);
            return View();
        }
    }
}