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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager cm = new MessageManager(new EfMessageDal());
        ContentManager conm = new ContentManager(new EfContentDal());
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var value = cm.GEtlistInbox(p);
            ViewBag.messageCount = cm.GEtlistInbox(p).Count();
            ViewBag.sendcount = cm.GEtlistSendbox(p).Count();

            return View(value);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];

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
            string sender = (string)Session["WriterMail"];

            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Now;
                cm.MessageAdd(p);
                return RedirectToAction("SendBox");
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
        public ActionResult GetInboxDetail(int id)
        {
            var value = cm.GetById(id);
            return View(value);
        }
    }

}