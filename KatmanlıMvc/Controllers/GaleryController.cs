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
    [Authorize(Roles ="A")]

    public class GaleryController : Controller
    {
        // GET: Gallery
        ImageManager ım = new ImageManager(new EfImageDal());
        public ActionResult Index()
        {
            var value = ım.GEtlist();
            return View(value);
        }
        public ActionResult Index2()
        {
            var value = ım.GEtlist();
            return View(value);
        }
    }
}