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

            int k = ability.AbilityValue * 2;
            ability.AbilitBarsValue = k;
            am.AbilityAdd(ability);
            return View();
        }
        public ActionResult YetenekDüzenle()
        {
            var value = am.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult YetenekEdit(int id)
        {
            var value = am.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult YetenekEdit(Ability m)
        {
            int k = m.AbilityValue * 2;
            m.AbilitBarsValue = k;
            am.AbilityEdit(m);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var value = am.GetByID(id);

            am.AbilityDelete(value);
            return RedirectToAction("Index");
        }
    }
}