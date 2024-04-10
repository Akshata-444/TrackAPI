using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.DTO;
using TrackAPI.Services;
using static TrackAPI.Models.TaskSubmission;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskSubController : ControllerBase
    {
        private readonly TaskSubServices tasksubservice;

        public TaskSubController(TaskSubServices tasksubservice)
        {
            this.tasksubservice = tasksubservice;
        }

        [HttpPost]
        public async Task<ActionResult<TaskSubmissions>> SubmitTask([FromForm] TaskSub taskSubmission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await tasksubservice.SubmitTask(taskSubmission);
            return Ok(result);
        }

         [HttpGet("{subtaskId}")]
        public async Task<ActionResult<List<byte[]>>> GetSubmissionsBySubtaskId(int subtaskId)
        {
            var submissions = await tasksubservice.GetSubmissionsBySubtaskId(subtaskId);
            if (submissions == null)
            {
                return NotFound();
            }

            return Ok(submissions);
        }

    }
}