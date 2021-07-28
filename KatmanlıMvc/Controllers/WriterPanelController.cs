using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWritterDal());
        ContentManager conm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult WriterPanel()
        {
            return View();
        }
        public ActionResult WriterBaslıklarım(string p)
        {
            p = (string)Session["WriterMail"];
            var vritridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var value = hm.GetListbyWriter(vritridinfo);
            return View(value);
        }
        public ActionResult Delete(int id)
        {
            var value = hm.GetById(id);
            hm.HEadingDelete(value);
            return RedirectToAction("WriterBaslıklarım");
        }
        [HttpGet]
        public ActionResult WriterHeadingAdd()
        {
            List<SelectListItem> ctg = (from i in cm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = i.CategoryName,
                                            Value = i.CategoryID.ToString()
                                        }
                                       ).ToList();
            ViewBag.categories = ctg;

           

            return View();
        }
        [HttpPost]
        public ActionResult WriterHeadingAdd(Heading p)
        {
            p.Headingdate = DateTime.Now;
            string writermailinfo = (string)Session["WriterMail"];
            var vritridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = vritridinfo;
            hm.HeadingAdd(p);
            return RedirectToAction("WriterBaslıklarım");
        }
        [HttpGet]

        public ActionResult WriterHeadingEdit(int id)
        {
            List<SelectListItem> ctg = (from i in cm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = i.CategoryName,
                                            Value = i.CategoryID.ToString()
                                        }
                                      ).ToList();
            ViewBag.categories = ctg;

            var value = hm.GetById(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult WriterHeadingEdit(Heading p)
        {
         
            hm.HeadingUpdate(p);
            return RedirectToAction("WriterBaslıklarım");
        }
        public ActionResult Headings(int p=1)
        {
            var value = hm.GEtlist().ToPagedList(p,2);

            return View(value);
        }
        public ActionResult WriterContents(int id)
        {
            var value = conm.GetListByHeadingId(id);

            return View(value);
        }
        [HttpGet]
        public ActionResult NewContent(int id)
        {
            ViewBag.headingId = id;
            var val = hm.GetById(id);
            string val2 = val.HeadingName;
            ViewBag.başlıkismi = val2;

            //var x = conm.GetById(id);
            //string value= x.Heading.HeadingName;
            //ViewBag.HeadingValue = value.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult NewContent(Content p)
        {
            p.ContentDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            string writermailinfo = (string)Session["WriterMail"];
            var vritridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = vritridinfo;
            conm.ContentAdd(p);

            return RedirectToAction("Headings");
        }

    }
}