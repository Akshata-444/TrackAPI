using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.DTO;
using TrackAPI.Services;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginservice;

        public LoginController(LoginService loginservice)
        {
             this.loginservice = loginservice;

        }


[HttpPost]
[AllowAnonymous]
[Route("Login")]
public async Task<ActionResult>  LoginUser([FromBody]Login user)//Try [FromBody]
{
    try
    {
        
        var res = await loginservice.LoginUser(user);
        if(res == null)
        {
            return BadRequest();
        }
        return Ok(res);
    }
    catch (Exception ex)
    {
        return StatusCode(500, ex.Message);
    }
}

}}