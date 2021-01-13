using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commander.Data;
using Microsoft.AspNetCore.Identity;
using Commander.Models;
using Microsoft.AspNetCore.Cors;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignUpUserModel user)
        {

            var result = await _accountRepository.CreateUserAsync(user);
            if(!result.Succeeded)
            {
                return new NotFoundResult();
            }
            return Ok();
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody]SignInUserModel user)
        {
            if (await _accountRepository.IsValidUsernameAndPassword(user.Email, user.Password))
            {
                return new ObjectResult(await _accountRepository.GenerateToken(user.Email));
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
