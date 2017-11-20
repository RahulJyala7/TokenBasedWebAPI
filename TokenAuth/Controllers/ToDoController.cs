using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAuth.Interface;
using TokenAuth.Models;

namespace TokenAuth.Controllers
{
    public class ToDoController : ApiController
    {
        private SampleEntities db = new SampleEntities();
        [HttpGet]
        public TokenEntities GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };
            db.Tokens.Add(tokendomain);
            db.SaveChanges();
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
            throw new NotImplementedException();
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
