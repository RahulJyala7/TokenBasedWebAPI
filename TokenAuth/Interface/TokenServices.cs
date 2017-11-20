using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TokenAuth.Models;

namespace TokenAuth.Interface
{
    public class TokenServices : ITokenServices
    {

        private SampleEntities db = new SampleEntities();
        public Models.TokenEntities GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };
            db.Tokens.Add(tokendomain);
            db.SaveChanges();
            //_unitOfWork.TokenRepository.Insert(tokendomain);
            //_unitOfWork.Save();

            
            var tokenModel = new TokenEntities()
            {
                UserId = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }

        public bool ValidateToken(string tokenId)
        {
           var token = db.Tokens.SingleOrDefault(t => t.AuthToken == tokenId );
          if (token != null )
          {
              token.ExpiresOn = token.ExpiresOn.AddSeconds(
                                            Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
              //_unitOfWork.TokenRepository.Update(token);
             // _unitOfWork.Save();
              db.SaveChanges();
              return true;
          }
          return false;
        }

        public bool Kill(string tokenId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}