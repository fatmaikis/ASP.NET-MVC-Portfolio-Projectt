using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class SocialMediaController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList();
            return View(values);
        }

        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socialMedias)
        {
            var value = db.TblSocialMedias.Add(socialMedias);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialMedias)
        {
            var value = db.TblSocialMedias.Find(socialMedias.SocialMediaID);
            value.SocialMediaName = socialMedias.SocialMediaName;   
            value.Url = socialMedias.Url;
            value.Icon=socialMedias.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}