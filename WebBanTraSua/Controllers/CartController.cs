using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Common;
using WebBanTraSua.Models;
using WebBanTraSua.Models.DAO;

namespace WebBanTraSua.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart
        public ActionResult ListItemInCart()
        {
            var cart = Session[CommenConstants.CartSession];
            var listItem = new List<CartModel>();
            if (cart != null)
            {
                listItem = (List<CartModel>)cart;
            }

            return View(listItem);
        }

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
            return RedirectToAction("ListItemInCart");
        }
    }
}