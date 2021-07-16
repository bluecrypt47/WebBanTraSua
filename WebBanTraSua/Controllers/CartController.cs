using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebBanTraSua.Code;
using WebBanTraSua.Common;
using WebBanTraSua.Models;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommenConstants.CartSession];
            var listItem = new List<CartModel>();
            if (cart != null)
            {
                listItem = (List<CartModel>)cart;
            }

            return View(listItem);
        }

        // Thêm mặt hàng vào Giỏ
        public ActionResult AddCart(long maSanPham, int soLuong)
        {
            var product = new SanPhamDAO().GetByID(maSanPham);
            var cart = Session[CommenConstants.CartSession];

            if (cart != null)
            {
                var listItem = (List<CartModel>)cart;

                if (listItem.Exists(x => x.SanPham.maSanPham == maSanPham))
                {
                    foreach (var item in listItem)
                    {
                        if (item.SanPham.maSanPham == maSanPham)
                        {
                            item.SoLuong += soLuong;
                        }
                    }
                }
                else
                {
                    // Tạo mới 1 product vào cart
                    var item = new CartModel();

                    item.SanPham = product;
                    item.SoLuong = soLuong;
                    listItem.Add(item);
                }

                // Gán listItem vào session
                Session[CommenConstants.CartSession] = listItem;
            }
            else
            {
                // Tạo mới 1 product vào cart
                var item = new CartModel();

                item.SanPham = product;
                item.SoLuong = soLuong;
                var listItem = new List<CartModel>();
                listItem.Add(item);
                // Gán listItem vào session
                Session[CommenConstants.CartSession] = listItem;
            }
            return Redirect("/");
        }

        // Cập nhật lại giỏ hành
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartModel>>(cartModel);
            var sessionCart = (List<CartModel>)Session[CommenConstants.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.maSanPham == item.SanPham.maSanPham);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CommenConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CommenConstants.CartSession] = null;

            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartModel>)Session[CommenConstants.CartSession];
            sessionCart.RemoveAll(x => x.SanPham.maSanPham == id);

            Session[CommenConstants.CartSession] = sessionCart;

            return Json(new
            {
                status = true
            });
        }

        // Thanh toán
        public ActionResult Checkout()
        {
            var cart = Session[CommenConstants.CartSession];
            var listItem = new List<CartModel>();
            if (cart != null)
            {
                listItem = (List<CartModel>)cart;
            }

            //var sessionUser = Session[CommenConstants.USER_SESSION];
            //sessionUser = new TaiKhoanSession();
            //var user = new TaiKhoanDAO().getByEmail(sessionUser.);
            //var bill = new HoaDon();

            //if (user != null)
            //{
            //    bill.email = user.email;
            //    bill.tenNguoiMua = user.tenNguoiDung;
            //    bill.diaChi = user.diaChi;
            //    bill.sdt = user.sdt;
            //}

            return View(listItem);
        }

        [HttpPost]
        public ActionResult Checkout(string email, string name, string address, string phoneNumber, string note)
        {
            try
            {
                var bill = new HoaDon();

                bill.email = email;
                bill.tenNguoiMua = name;
                bill.diaChi = address;
                bill.sdt = phoneNumber;
                bill.ghiChu = note;
                bill.ngayMua = DateTime.Now;

                try
                {
                    var id = new HoaDonDAO().InsertBill(bill);

                    var cart = (List<CartModel>)Session[CommenConstants.CartSession];
                    var chiTietHoaDonDAO = new ChiTietHoaDonDAO();

                    foreach (var item in cart)
                    {
                        var chiTietHoaDon = new ChiTietHoaDon();

                        chiTietHoaDon.maSanPham = item.SanPham.maSanPham;
                        chiTietHoaDon.maHoaDon = id;
                        chiTietHoaDon.soLuong = item.SoLuong;
                        chiTietHoaDon.giaBan = item.SanPham.giaBan;
                        chiTietHoaDon.thanhTien = (item.SoLuong * item.SanPham.giaBan);

                        chiTietHoaDonDAO.InsertBill(chiTietHoaDon);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                Session[CommenConstants.CartSession] = null;

                return Redirect("/hoan-thanh");
            }catch(Exception ex)
            {
                ViewBag.Error = "Vui lòng điền đủ thông tin yêu cầu!";
                return View("Checkout");
            }
            
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}