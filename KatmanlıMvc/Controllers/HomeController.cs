using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Vitrin()
        {
            return View();
        }

      
    }
}