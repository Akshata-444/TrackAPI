using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.DTO;
using TrackAPI.Models;
using TrackAPI.Services;
using static TrackAPI.Models.TaskSubmissions;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskSubController : ControllerBase
    {
        private readonly TaskSubServices tasksubservice;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public TaskSubController(TaskSubServices tasksubservice,IWebHostEnvironment webHostEnvironment)
        {
            this.tasksubservice = tasksubservice;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet("{subtaskId}/{TaskSubmissionsId}/Download")]
        public async Task<IActionResult> DownloadSubmission(int subtaskId, int TaskSubmissionsId)
        {
            var submissions = await tasksubservice.GetSubmissionsBySubtaskIdAndUserId(subtaskId, TaskSubmissionsId);
    if (submissions == null || submissions.Count == 0)
    {
        return NotFound("No submissions found for the provided subtask ID and user ID.");
    }

    var submission = submissions[0]; // Assuming you want to download the first submission
    var fileContent = submission.Item2; // Extracting the byte array from the tuple

    // Specify the file name for download
    var fileName = submission.Item1; // Extracting the file name from the tuple
    var contentType = "application/octet-stream"; // Change content type accordingly

    return File(fileContent, contentType, fileName);
}
     


        [HttpPost("subtaskId/Submit")]
        public async Task<ActionResult<TaskSubmissions>> SubmitTask([FromForm] TaskSub taskSubmission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           try
    {
        var result = await tasksubservice.SubmitTask(taskSubmission);
        return Ok(result);
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(ex.Message);
    }
}

   /* [HttpGet("{subtaskId}/users")]
        public async Task<ActionResult<List<int>>> GetUsersBySubtaskId(int subtaskId)
        {
            var userIds = await tasksubservice.GetUsersBySubtaskId(subtaskId);
            return Ok(userIds);
        }*/

     [HttpGet("{subtaskId}")]
        public async Task<ActionResult<List<TaskSubmissions>>> GetSubmissionsBySubtaskIdAsync(int subtaskId)
        {
            var submissions = await tasksubservice.GetSubmissionsBySubtaskIdAsync(subtaskId);
            if (submissions == null || submissions.Count == 0)
            {
                return NotFound();
            }
            return Ok(submissions);
        }
    }}
