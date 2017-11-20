using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenAuth.Interface
{
    interface IUserServices
    {
        int Authenticate(string userName, string password);
    }
}
