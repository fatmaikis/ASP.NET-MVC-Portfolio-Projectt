using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmins admin)
        {
            var values = db.TblAdmins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["userName"] = values.UserName;
                return RedirectToAction("Index","About");
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı adı veya şifre yanlış");
                return View();
            }
           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Default");  
        }
    }
}