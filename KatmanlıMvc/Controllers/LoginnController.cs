using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KatmanlıMvc.Controllers
{
    [AllowAnonymous]

    public class LoginnController : Controller
    {
        // GET: Loginn
        AdminManager am = new AdminManager(new EfAdminDal());
        Context c = new Context();

        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var value = am.IsLoginSuccess(admin.AdminUserName, admin.AdminPassword);


            if (value == true)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
                Session["AdminUserName"] = admin.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            return RedirectToAction("Index", "Admin");

        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AddAdmin()
        {

            List<SelectListItem> valueRole = new List<SelectListItem>()
            {
                new SelectListItem {
                    Text="A",
                    Value="A"
                },
                new SelectListItem
                {
                     Text="B",
                    Value="B"
                },
                new SelectListItem
                {
                     Text="C",
                    Value="C"
                },

            };
            ViewBag.vr = valueRole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            am.AddAdmin(admin);
            return RedirectToAction("Index", "AdminCategory");
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("WriterContent", "Content");
            }
            else
            {
                return RedirectToAction("WriterLogin");

            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
        public ActionResult Admin()
        {
            var value = am.GEtlist();
            return View(value);
        }
        [HttpGet]
        public ActionResult AdminDüzenle(int id)
        {

            List<SelectListItem> valueRole = new List<SelectListItem>()
            {
                new SelectListItem {
                    Text="A",
                    Value="A"
                },
                new SelectListItem
                {
                     Text="B",
                    Value="B"
                },
                new SelectListItem
                {
                     Text="C",
                    Value="C"
                },
               
            };
            ViewBag.vr = valueRole;
            var value = am.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdminDüzenle(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Admin");
        }
    }
}