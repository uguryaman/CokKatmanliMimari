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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWritterDal());
        public ActionResult Index()
        {
            var value = hm.GEtlist();
            return View(value);
        }
        public ActionResult HeadingReports()
        {
            var value = hm.GEtlist();
            return View(value);
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> ctg = (from i in cm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = i.CategoryName,
                                            Value = i.CategoryID.ToString()
                                        }
                                        ).ToList();
            ViewBag.categories = ctg;

            List<SelectListItem> yzr = (from i in wm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = i.WriterName + " " + i.WriterSurname,
                                            Value = i.WriterID.ToString()
                                        }
                                       ).ToList();
            ViewBag.Writers = yzr;
            return View();
        }
        public ActionResult HeadingAdd(Heading heading)
        {
            heading.Headingdate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public PartialViewResult HedingUpdate()
        {

            return PartialView();
        }
    }
}
