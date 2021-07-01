using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Categories.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Headings.Count(x => x.Category.CategoryName == "yazılım").ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Headings.GroupBy(x => x.Category.CategoryName).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d4 = deger4;

            var deger5 =(( c.Categories.Count(x => x.CategoryStatus == true))- (c.Categories.Count(x => x.CategoryStatus == false))).ToString();           
            ViewBag.d5 = deger5;


            return View();
        }
    }
}