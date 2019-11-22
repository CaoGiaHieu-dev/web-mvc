using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model
{
    public class Account
    {
        private NewsDbContext db = null;
        public Account()
        {
            db = new NewsDbContext();
        }
        public bool login(string user , string pass)
        {
            object[] sqlq =
            {
                new SqlParameter("username",user),
                new SqlParameter("password",pass),

            };
            var result = db.Database.SqlQuery<bool>("admin @username,@password", sqlq).FirstOrDefault();
            return result;
        }
    }
}
