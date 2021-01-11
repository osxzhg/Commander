using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commander.Data;
using Microsoft.AspNetCore.Identity;
using Commander.Models;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> SignIn(SignInUserModel user)
        {
            if (await _accountRepository.IsValidUsernameAndPassword(user.Email, user.Password))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
