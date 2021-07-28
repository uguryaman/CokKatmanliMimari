using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    [AllowAnonymous]

    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cntm = new ContentManager(new EfContentDal());
        public ActionResult Index(int id)
        {

            var Value = cntm.GetListByID(id);
            return View(Value);
        }
        public ActionResult WriterContent(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var value = cntm.GetListByWriter(writerIdInfo);
            return View(value);
        }
        public ActionResult ContentToHeading(int id)
        {
            var value = cntm.GetListByHeadingId(id);
            return View(value);
        }
        public ActionResult GetAllContent(string p)
        {

            var value = cntm.GetListSearch(p);
            return View(value);
        }

    }
}