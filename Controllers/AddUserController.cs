using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.Models;
using TrackAPI.Services;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddUserController : ControllerBase
    {
        private readonly ADDUSERServices UserService;

        public AddUserController(ADDUSERServices UserProfileServices)
{
    this.UserService = UserProfileServices;

    }

//change role to admin , admin will add mentor 
[HttpPost]
[Authorize(Roles ="Mentor")]
[Route("AddEmployee")]
public async Task<ActionResult>  AddUser([FromBody]ADDUSER user)//Try [FromBody]
{
try{ 
    var res = await UserService.AddUser(user);
        if(res == null)
        {
            return BadRequest();
        }
        return Ok(new{message=res});
    }
    catch (Exception ex)
    {
        return StatusCode(500, ex.Message);
    }
}
}
}