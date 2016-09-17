using AOAuthServer.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AOAuthServer.Controllers
{
    public enum ResponseType 
    {
        code,
        token,
        refreshtoken
    }


    [RoutePrefix("api/oauth")]
    public class OAuthController : ApiController
    {
        public Dictionary<String, String> ClientsList = new Dictionary<String, String>();
        public Dictionary<String, AccessToken> AccessTokensList = new Dictionary<String, AccessToken>();
        
        [HttpGet]
        [Route("authorize")]
        public IHttpActionResult Authorize(AuthorizeRequest request)
        {
            Boolean IsClientExists = ( ClientsList.Where(c => c.Key == request.clientId).ToArray<KeyValuePair<String,String>>().Length > 0);
            if (IsClientExists)
            {
                String user_id = User.Identity.GetUserId();
                AccessToken accessToken = new AccessToken
                {
                    value = "123456789==",
                    clientId = request.clientId,
                    userId = user_id
                };
                AccessTokensList.Add(request.clientId, accessToken);
                
                return Ok( accessToken);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("token")]
        public IHttpActionResult token()
        {
            IdentityResult result;
            return Ok();
        }
    }
}
