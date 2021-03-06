﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace TokenAuth.ActionFilter
{


    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }

        public BasicAuthenticationIdentity(string userName, string password)

            : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
        }
    }

}



