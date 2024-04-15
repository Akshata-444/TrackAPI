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
using Microsoft.Extensions.Configuration; 

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

 [HttpGet("GetuserByUserId/{userId}")]
        public async Task<ActionResult<User>> GettUser(int userId)
        {
            try
            {
                var user = await UserService.GettUser(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    

//change role to admin , admin will add mentor 
[HttpPost]
//[Authorize(Roles ="Mentor,Admin")]
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