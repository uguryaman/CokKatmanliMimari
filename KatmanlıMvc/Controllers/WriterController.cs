using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wm = new WriterManager(new EfWritterDal());
        public ActionResult Index()
        {
            var WriterValue = wm.GetList();
            return View(WriterValue);
        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(Writer p)
        {
            WriterValidatior writerValidatior = new WriterValidatior();
            ValidationResult results = writerValidatior.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult Writerdelete(int id)
        {
            var p = wm.GetByID(id);
            wm.WriterDelete(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult WriteEdit(int id)
        {
            var WriteValue = wm.GetByID(id);

            return View(WriteValue);
        }
        [HttpPost]
        public ActionResult WriteEdit(Writer p)
        {

            WriterValidatior writerValidatior = new WriterValidatior();
            ValidationResult results = writerValidatior.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();
        }

    }
}