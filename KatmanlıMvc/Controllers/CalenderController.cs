using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using KatmanlıMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class CalenderController : Controller
    {
		// GET: Calender
		HeadingManager headingManager = new HeadingManager(new EfHeadingDal());

		public ActionResult Index()
		{
			return View(new HeadingClasses());
		}

		public JsonResult GetEvents(DateTime start, DateTime end)
		{
			var viewModel = new HeadingClasses();
			var events = new List<HeadingClasses>();
			start = DateTime.Today.AddDays(-14);
			end = DateTime.Today.AddDays(-11);

			foreach (var item in headingManager.GEtlist())
			{
				events.Add(new HeadingClasses()
				{
					id = item.HeadingID,
					title = item.HeadingName,
					start = item.Headingdate,
					end = item.Headingdate.AddDays(-14),
					allDay = false
				});

				start = start.AddDays(7);
				end = end.AddDays(7);
			}


			return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
		}
	}
}