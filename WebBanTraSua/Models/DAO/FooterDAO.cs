using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class FooterDAO
    {
        WTSDBContext db = null;

        public FooterDAO()
        {
            db = new WTSDBContext();
        }

        // Lấy danh sách
        public List<Footer> listMenus()
        {
            return db.Footers.OrderBy(x => x.maFooter).ToList();
        }
    }
}