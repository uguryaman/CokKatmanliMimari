using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KatmanlıMvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
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
        [Authorize(Roles="A")]
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {           
            am.AddAdmin(admin);  
            return RedirectToAction("Index","AdminCategory");
        }
      

    }
}
