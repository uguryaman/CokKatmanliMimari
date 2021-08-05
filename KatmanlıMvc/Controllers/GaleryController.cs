using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult ImageAdd()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult ImageAdd(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/GaleriImage/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.ImagePath = "/GaleriImage/" + fileName;
              
            }

          
            ım.ImageAdd(p);
            return RedirectToAction("Index");
        }
    }
}