using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanTraSua.Common;
using WebBanTraSua.Models;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                var taikhoanDAO = new TaiKhoanDAO();

                if (taikhoanDAO.CheckEmail(register.email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại!!!");
                }
                else
                {
                    var taiKhoan = new TaiKhoan();

                    taiKhoan.email = register.email;
                    taiKhoan.matKhau = Encrypt.MD5Hash(register.password);
                    taiKhoan.tenNguoiDung = register.name;
                    taiKhoan.diaChi = register.address;
                    taiKhoan.sdt = register.phoneNumber;
                    taiKhoan.ngayTao = DateTime.Now;

                    var result = taikhoanDAO.insert(taiKhoan);

                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công!";
                        register = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại!");
                    }
                }
            }
            return View(register);
        }

        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(LoginUserModel login)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.Login(login.email, Encrypt.MD5Hash(login.passowrd));
                if (result && ModelState.IsValid)
                {
                    //SessionHelper.setSession(new TaiKhoanSession() { email = login.Email });
                    var user = dao.getByEmail(login.email);
                    var userSession = new UserLogin();
                    userSession.Email = user.email;
                    userSession.Id = user.id;
                    Session.Add(CommenConstants.USER_SESSION, userSession);

                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!!!");
                }
            }

            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session[CommenConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult InformationUser(long idUser)
        {
            var user = new TaiKhoanDAO().GetByID(idUser);
            return View(user);
        }

        [HttpPost]
        public ActionResult InformationUser(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();

                if (!string.IsNullOrEmpty(user.matKhau))
                {
                    user.matKhau = Encrypt.MD5Hash(user.matKhau);
                }

                var result = dao.edit(user);

                if (result)
                {
                    //ViewBag.Success("Cập nhật Thông tin thành công!!!", "success");
                    //return RedirectToAction("InformationUser", "LoginUser");
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Thông tin thất bại!!");
                }
            }
            return View("InformationUser");
        }
    }
}