using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models
{
    [Serializable]
    public class CartModel
    {
        private SanPham sanPham;
        private int soLuong;

        public SanPham SanPham { get => sanPham; set => sanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}