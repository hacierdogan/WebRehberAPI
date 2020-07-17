using Rehber.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Rehber.API.Security
{
    public class APIKeyHandler:DelegatingHandler
    {

        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();

            KullanicilarDAL userDAL = new KullanicilarDAL();
            var user = userDAL.GetUserByApiKey(apiKey);
            if (user != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.UserName, "APIkey"));
                HttpContext.Current.User = principal;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}