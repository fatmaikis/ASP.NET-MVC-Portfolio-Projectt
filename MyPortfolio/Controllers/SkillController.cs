using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblSkills.ToList();
            return View(value);
        }

        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkills skills)
        {
            var value = db.TblSkills.Add(skills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkills.Find(id);
            db.TblSkills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var result = db.TblSkills.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkills skills)
        {
            var value = db.TblSkills.Find(skills.SkillID);
            value.SkillName = skills.SkillName; 
            value.Value= skills.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}