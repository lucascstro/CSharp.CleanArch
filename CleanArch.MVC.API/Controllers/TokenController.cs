using Microsoft.AspNetCore.Mvc;
using CleanArch.MVC.Domain.Account;
using CleanArch.MVC.API.Models;

namespace CleanArch.MVC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        public TokenController(IAuthenticate authentication)
        {
            this._authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
        }

       [HttpPost("LoginUser")]
       public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model){
        var result = await _authentication.Authenticate(model.Email, model.Password);

        if(result)
        {
            //return GenerateToken(useInfo);
            return Ok($"{model.Email}");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
            return BadRequest(ModelState);
        }
       }
    }
}