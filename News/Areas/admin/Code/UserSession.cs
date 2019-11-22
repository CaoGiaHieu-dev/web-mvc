using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Areas.admin.Code
{
    [Serializable]
    public class UserSession
    {
        public string username { set; get; }
    }
}