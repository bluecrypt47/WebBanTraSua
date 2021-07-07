using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Common;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // Lấy danh sách user và phân trang cho trang user
        public ActionResult ListUser(string searchUser, int page = 1, int pageSize = 10)
        {
            var dao = new TaiKhoanDAO();
            var model = dao.ListAllPaging(searchUser, page, pageSize);
            ViewBag.searchUser = searchUser;
            return View(model);
        }

        // Thêm 1 tài khoản
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();

                // Mã hóa password
                var encryptPass = Encrypt.MD5Hash(user.matKhau);
                user.matKhau = encryptPass;

                long id = dao.insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm Tài khoản thành công!!!", "success");
                    return RedirectToAction("ListAdmin", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Tài khoản thất bại!!");
                }
            }
            return View("ListAdmin");
        }

        // Cập nhật tài khoản
        public ActionResult Edit(long id)
        {
            var user = new TaiKhoanDAO().GetByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(TaiKhoan user)
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
                    SetAlert("Cập nhật Tài khoản thành công!!!", "success");
                    return RedirectToAction("ListUser", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Tài khoản thất bại!!");
                }
            }
            return View("ListUser");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new TaiKhoanDAO().Delete(id);

            SetAlert("Xóa Tài khoản thành công!!!", "success");
            return RedirectToAction("ListUser", "Admin");
        }



        // Lấy danh sách Admin và phân trang cho trang Admin
        public ActionResult ListAdmin(string searchAdmin, int page = 1, int pageSize = 10)
        {
            var dao = new TaiKhoanDAO();
            var model = dao.ListAllPagingAdmin(searchAdmin, page, pageSize);
            ViewBag.searchAdmin = searchAdmin;
            return View(model);
        }


        // Cập nhật tài khoản
        public ActionResult EditAdmin(long id)
        {
            var user = new TaiKhoanDAO().GetByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditAdmin(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();

                //if(!string.IsNullOrEmpty(user.matKhau))
                //{
                //    var encryptPass = Encrypt.MD5Hash(user.matKhau);
                //    user.matKhau = encryptPass;
                //}

                var result = dao.edit(user);

                if (result)
                {
                    SetAlert("Cập nhật Tài khoản thành công!!!", "success");
                    return RedirectToAction("ListAdmin", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Tài khoản thất bại!!");
                }
            }
            return View("ListAdmin");
        }

        [HttpDelete]
        public ActionResult DeleteAdmin(long id)
        {
            new TaiKhoanDAO().Delete(id);

            SetAlert("Xóa Tài khoản thành công!!!", "success");
            return RedirectToAction("ListAdmin", "Admin");
        }
    }
}