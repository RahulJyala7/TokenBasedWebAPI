using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAuth.ActionFilter;
using TokenAuth.Models;

namespace TokenAuth.Controllers
{
  //  [ApiAuthenticationFilter]
    [AuthorizationRequired]
    public class BooksController : ApiController
    {
        private SampleEntities db = new SampleEntities();
         public HttpResponseMessage Get() 
        {
         var R =   db.Books.ToList();
         return Request.CreateResponse(HttpStatusCode.OK , R);

          
        }
    }
}
