using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetBackendTemplate.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(AccountForLoginDto accountForLoginDto)
        {
            var accountToLogin = _authService.Login(accountForLoginDto);
            if (!accountToLogin.Success)
            {
                return BadRequest(accountToLogin.Message);
            }

            var result = _authService.CreateAccessToken(accountToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(AccountForRegisterDto accountForRegisterDto)
        {
            var accountExists = _authService.AccountExists(accountForRegisterDto.Email);
            if (!accountExists.Success)
            {
                return BadRequest(accountExists.Message);
            }

            var registerResult = _authService.Register(accountForRegisterDto, accountForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}

