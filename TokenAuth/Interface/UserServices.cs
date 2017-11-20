using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenAuth.Models;

namespace TokenAuth.Interface
{
    public class UserServices : IUserServices
    {
        private SampleEntities db = new SampleEntities();

        public int Authenticate(string userName, string password)
        {

            var user = db.User_.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if (user != null && user.UserId > 0)
            {
                return user.UserId;
            }
            return 0;
        }
    }
}
