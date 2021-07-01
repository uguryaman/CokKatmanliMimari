using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cntm = new ContentManager(new EfContentDal());
        public ActionResult Index(int id)
        {

            var Value = cntm.GetListByID(id);
            return View(Value);
        }
    }
}