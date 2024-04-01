using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblTeams.ToList();
            return View(value);
        }

        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(TblTeams teams)
        {
            var value = db.TblTeams.Add(teams);
            db.SaveChanges();
            return RedirectToAction("Index");   

        }

        public ActionResult DeleteTeam(int id)
        {
            var value = db.TblTeams.Find(id);
            db.TblTeams.Remove(value);  
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var value = db.TblTeams.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateTeam(TblTeams teams)
        {
            var value = db.TblTeams.Find(teams.TeamID);
            value.ImageUrl= teams.ImageUrl; 
            value.NameSurname= teams.NameSurname;   
            value.Title= teams.Title;
            value.Description=teams.Description;
            value.TwitterUrl= teams.TwitterUrl;
            value.FacebookUrl= teams.FacebookUrl;
            value.LinkedinUrl= teams.LinkedinUrl;
            value.InstagramUrl= teams.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");   

        }

        
    }
}