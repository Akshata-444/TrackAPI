//using Microsoft.CodeAnalysis.CSharp.Syntax;
using TrackAPI.Interfaces;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.DTO;
using TrackAPI.Services;
using TrackAPI.Models;
using System.Linq;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddTaskController : ControllerBase
    {
        private readonly AddTaskServices _taskServices;

        public AddTaskController(AddTaskServices taskServices)
        {
            _taskServices = taskServices;
        }

       
 [HttpPost("batches/{batchId}/tasks")]
public async Task<IActionResult> AssignTaskToBatch(int batchId, [FromBody] AddTask taskDto)
{
    try
    {
        int taskId = await _taskServices.AssignTaskToBatch(batchId, taskDto);
        //return CreatedAtRoute("TaskCreated", new { batchId, taskId }, taskDto);
        //return CreatedAtAction(nameof(AssignTaskToBatch), new { batchId = batchId }, taskDto);
        return Ok(taskDto);

    }
    catch (InvalidOperationException ex)
    {
        return NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Internal server error: " + ex.Message);
    }
}


    }
}
