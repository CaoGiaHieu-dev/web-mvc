using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Model.DAO
{
    public class AccountDAO
    {
        NewsDbContext db = null;
        public AccountDAO()
        {
            db = new NewsDbContext();
        }
        public bool login(string user , string password)
        {
            var result = db.User.Count(x => x.Username == user && x.Password == password);
            if(result >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User getID(string user)
        {
            return db.User.SingleOrDefault(x => x.Username == user);
        }
    }
}
