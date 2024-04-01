using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblFeatures.ToList();
            return View(value);
        }

        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeatures features)
        {
            db.TblFeatures.Add(features);
            db.SaveChanges();
            return RedirectToAction("Index");   

        }
        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(value);
            db.SaveChanges();   
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeatures features)
        {
            var value = db.TblFeatures.Find(features.FeatureID);
            value.NameSurname = features.NameSurname;
            value.Title = features.Title;   
            value.ImageUrl=features.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}