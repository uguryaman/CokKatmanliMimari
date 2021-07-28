using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal()); 
        public ActionResult Index()
        {
            var values = hm.GEtlist();
            return View(values);
        }
        public ActionResult ContentList()
        {
            var value = cm.GetList();
            return PartialView(value);
        }
        public ActionResult HeadingIdList(int id)
        {
            var value = cm.GetListByHeadingId(id);
            return PartialView(value);
        }
    }
}
