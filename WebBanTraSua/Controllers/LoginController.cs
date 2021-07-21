using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanTraSua.Common;
using WebBanTraSua.Models;
using WebBanTraSua.Models.DAO;

namespace WebBanTraSua.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.Login(login.Email, Encrypt.MD5Hash(login.MatKhau));
                if (result && ModelState.IsValid)
                {
                    var user = dao.getByEmail(login.Email);
                    var userSession = new UserLogin();
                    userSession.Email = user.email;
                    userSession.Id = user.id;
                    Session.Add(CommenConstants.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!!!");
                }
                //return View(login);
            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}