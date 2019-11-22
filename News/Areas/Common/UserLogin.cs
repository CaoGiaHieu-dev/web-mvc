using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Areas.Common
{
    [Serializable]
    public class UserLogin
    {
        public int ID { set; get; }
        public string Username { set; get; }
        public string Fullname { set; get; }
    }
}