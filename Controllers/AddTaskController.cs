using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using TrackAPI.Interfaces;
using TrackAPI.DTO;
using TrackAPI.Models;
using TrackAPI.Services;


namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddTaskController : ControllerBase
    {
        private readonly AddTaskServices UserService;

        public AddTaskController(AddTaskServices TaskServices)
{
    this.UserService = TaskServices;


    }
    

    [HttpPost]
    public async Task<ActionResult> AddTask([FromBody]AddTask tas)
    {
        try{ 
    var res = await UserService.AddTask(tas);
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