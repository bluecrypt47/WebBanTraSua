using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanTraSua.Code
{
    [Serializable]
    public class TaiKhoanSession
    {
        public long userID { get; set; }
        public string email { get; set; }
    }
}