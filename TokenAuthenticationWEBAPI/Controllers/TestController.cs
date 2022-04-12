using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace TokenAuthenticationWEBAPI.Controllers
{
    public class TestController : ApiController
    {
        //-----------------------------------------------------------------------------------------
        // Fiddler request for getting token // uTube https://www.youtube.com/watch?v=B2jDN53taDk

        // POST : https://localhost:44323/token

        // Header
        // User-Agent: Fiddler
        // Host: localhost:44323
        // Content-Length: 51
        // Content-Type: application/x-www-form-urlencoded

        //  Body
        //  grant_type=password&username=Anurag&password=123456

        // Pass Token to controller

        // GET
        // Header
        //User-Agent: Fiddler
        //Host: localhost:44323
        //Content-Length: 0
        //Content-Type: application/json
        //Authorization: Bearer UlDW_wGtdSUy2UZ-5lMrqcNP-OBgjgIQCqzlS2F9qvYwbIxhSH3DwtS7ip4gaHAN03f-fQ2Qswc_7Jo8tyUFo2VpnnRg2wKHjxt7_t1Y4i-bKqalKPDcTdV0UgUIGJwur2v2aYbVSNAFVjjQ5g9Sb8Z0vxbxbUh-omrwooUlvZSn40jeDNgTaxwJ25eNsrqi68_C_j0xKCDyu90t4Db1HZ7p68uDwMXLpB4nr4GwMwmQSJkWxSvJRNYBlvrlWLNsuWlaADKiz5Fb6QjhYsa29StlERrezMpd0onr7PH0vFAOFLnDt8hsw4O6GcbnPabF
        //-----------------------------------------------------------------------------------------

        //This resource is For all types of role
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpPost]
        [Route("api/test/resource1")]
        public IHttpActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello: " + identity.Name);
        }

        //This resource is only For Admin and SuperAdmin role
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        [Route("api/test/resource2")]
        public IHttpActionResult GetResource2()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                      .FirstOrDefault(c => c.Type == "Email").Value;

            var UserName = identity.Name;

            return Ok("Hello " + UserName + ", Your Email ID is :" + Email);
        }

        //This resource is only For SuperAdmin role
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Route("api/test/resource3")]
        public IHttpActionResult GetResource3()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/test/AnonymousMethod")]
        public IHttpActionResult AnonymousMethod()
        {
            return Ok("All can access this one....");
        }
    }
}