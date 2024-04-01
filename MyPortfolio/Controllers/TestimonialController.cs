using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials testimonials) 
        { 
            var value = db.TblTestimonials.Add(testimonials);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials testimonials)
        {
            var value = db.TblTestimonials.Find(testimonials.TestimonialID);
            value.ImageUrl= testimonials.ImageUrl;  
            value.Comment= testimonials.Comment;
            value.NameSurname= testimonials.NameSurname;
            value.Title= testimonials.Title;    
            value.Status= testimonials.Status;
            value.CommentDate = testimonials.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}