using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanTraSua.Common
{
    [Serializable]
    public class UserLogin
    {
        private long id;
        private string email;

        public string Email { get => email; set => email = value; }
        public long Id { get => id; set => id = value; }
    }
}