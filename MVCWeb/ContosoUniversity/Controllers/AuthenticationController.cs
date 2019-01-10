using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.DAL;
using System.Web.Security;

namespace ContosoUniversity.Controllers
{
    [AllowAnonymous] //绑定允许匿名属性到认证控制器
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }
        //判断可以置入业务层
        [NonAction]
        public bool IsValidUser(UserDetails u)
        {
            using (var db = new SchoolContext())
            {
                return db.UserDbset.Any(o => o.UserName == u.UserName && o.Password == u.Password);
            }

        }
        [HttpPost]
        public ActionResult Login(UserDetails u)
        {
            if (IsValidUser(u))
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "用户名密码无效");
                return View("Login");
            }
        }
        //创建退出行为
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



    }
}