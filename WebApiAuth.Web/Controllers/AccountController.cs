using AttributeRouting.Web.Http;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiMvc.Filters.WebApi.Filters;


namespace WebApiMvc.Controllers
{

    [ApiAuthenticationFilter]
    public class AccountController : ApiController
    {
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [Route("Register")]
        public HttpResponseMessage Register(UserEntity userModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "UserName or Password is missing");
            }

          

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Authenticates user and returns token with expiry.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [POST("login")]
        [POST("authenticate")]
        public HttpResponseMessage Login([FromBody] UserEntity userEntity)
        {
            var s = userEntity;
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {

            }
            return null;
        }
    }
}
