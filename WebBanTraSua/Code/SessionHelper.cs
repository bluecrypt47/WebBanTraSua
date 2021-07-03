using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanTraSua.Code
{
    public class SessionHelper
    {
        // Tạo session khi đăng nhập
        public static void setSession(TaiKhoanSession session)
        {
            // Gán tài khoản hiện tại và biến session
            HttpContext.Current.Session["loginSession"] = session;
        }

        // Lấy session ra và dùng
        public static TaiKhoanSession getSession()
        {
            var session = HttpContext.Current.Session["loginSession"];

            if(session == null)
            {
                // return null nếu session = null 
                return null;
            }
            else
            {
                // Ngược lại sẽ cho session là tài khoản đăng nhập hiện tại
                return session as TaiKhoanSession;
            }
        }
    }
}