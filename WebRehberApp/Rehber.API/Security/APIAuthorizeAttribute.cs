using Rehber.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Rehber.API.Security
{
    public class APIAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var actionRoles = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            KullanicilarDAL userDAL = new KullanicilarDAL();
            var user = userDAL.GetUserByName(userName);
            if (user!=null&& actionRoles.Contains(user.UserRole))
            {
                
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized); 
            }
        }
    }
}