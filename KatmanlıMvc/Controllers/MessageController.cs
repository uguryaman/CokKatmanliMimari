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
    public class MessageController : Controller
    {
        MessageManager cm = new MessageManager(new EfMessageDal());

        // GET: Message
        public ActionResult Index()
        {
            string p="admin@gmail.com";
           var value= cm.GEtlistInbox(p);
            ViewBag.messageCount = cm.GEtlistInbox(p).Count();
            ViewBag.sendcount = cm.GEtlistSendbox(p).Count();

            return View(value);
        }
        public ActionResult SendBox()
        {
            string p = "admin@gmail.com";

            var value = cm.GEtlistSendbox(p);
            ViewBag.sendcount = cm.GEtlistSendbox(p).Count();
            ViewBag.messageCount = cm.GEtlistInbox(p).Count();


            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            MessageValidator messageValıdator = new MessageValidator();
            ValidationResult results = messageValıdator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "ugur@gmail.com";
                p.MessageDate = DateTime.Now;
                cm.MessageAdd(p);
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
        public ActionResult GetMessage(int id)
        {
           
            var value = cm.GetById(id);
            return View(value);
        }
    }
}