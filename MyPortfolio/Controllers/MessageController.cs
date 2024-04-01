using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values);
        }

        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(TblMessages messages)
        {
            var values = db.TblMessages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = db.TblMessages.Find(id);
            db.TblMessages.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var values = db.TblMessages.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateMessage(TblMessages messages)
        {
            var values = db.TblMessages.Find(messages.MessageID);
            values.Name = messages.Name;    
            values.Email= messages.Email;
            values.Subject=messages.Subject;
            values.MessageContent = messages.MessageContent;    
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}