using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAuth.Models;

namespace TokenAuth.Interface
{
  public   interface ITokenServices
    {
     
          TokenEntities GenerateToken(int userId);
          bool ValidateToken(string tokenId);
          bool Kill(string tokenId);
          bool DeleteByUserId(int userId);

      
    }
}
