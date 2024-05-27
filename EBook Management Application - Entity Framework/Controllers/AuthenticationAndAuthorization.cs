using Ebook.Data;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace EBook_Management_Application___Entity_Framework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationAndAuthorization : Controller
    {
        private readonly IAuthenticateAndAuthorize _authenticateAndAuthorizeService;

        public AuthenticationAndAuthorization(IAuthenticateAndAuthorize authenticateAndAuthorizeService)
        {
            _authenticateAndAuthorizeService = authenticateAndAuthorizeService;
        }

        [HttpPost]
        [Route("AddUser")]
        public ActionResult Signup([FromBody] DTOLoginRequest loginRequest)
        {
            return Ok(_authenticateAndAuthorizeService.Signup(loginRequest));
        }

        [HttpPost]
        [Route("Role")]
        public ActionResult Role([FromBody] DTOLoginRequest dTOLoginRequest)
        {
            return Ok(_authenticateAndAuthorizeService.RoleAssigned(dTOLoginRequest));
        }

        [HttpPost]
        [Route("Authentication")]
        public ActionResult GenerateJwtToken([FromBody] DTOLoginRequest loginRequest)
        {
            try
            {
                string role = _authenticateAndAuthorizeService.RoleAssigned(loginRequest);
                var jwtToken = _authenticateAndAuthorizeService.GenerateJwtToken(loginRequest, role);

                return Ok(jwtToken);
            }
            catch
            {
                return BadRequest("An error occurred in generating the token");
            }
        }
    }
}
