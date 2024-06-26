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

        [HttpDelete("subtasks/{subtaskId}")] // Specify unique route template for deleting subtasks
    public async Task<IActionResult> DeleteSubTask(int subTaskId)
    {
        var result = await _taskServices.DeleteSubTaskAsync(subTaskId);
       if (!result)
        return NotFound(); // Return 404 if the task was not found

    //return Ok("Task deleted successfully."); // Return a message confirming deletion
    return Ok(new {});
}

     [HttpDelete("{userTaskID}")]
public async Task<IActionResult> DeleteTask(int userTaskID)
{
    var result = await _taskServices.DeleteTask(userTaskID);
    if (!result)
        return NotFound(); // Return 404 if the task was not found

    //return Ok("Task deleted successfully."); // Return a message confirming deletion
    return Ok(new {});
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
 [HttpPost("add")]
        public async Task<IActionResult> AddNewSubtask([FromForm] AddSubTask subtask)
        {
            /*var result = await _taskServices.AddNewSubtask(subtask);
        
        if (result == "Task not found")
        {
            return NotFound(new { error = "Task not found" });
        }
        else if (result == "Subtask created successfully")
        {
            return Ok(new { message = "Subtask created successfully" });
        }
        else
        {
            // Handle other possible outcomes
            return BadRequest(new { error = "An error occurred" });
        }*/
    
            var result = await _taskServices.AddNewSubtask(subtask);
            return Ok(result);
        }

         [HttpGet("GetAlltasks/{batchId}/tasks")]
        public async Task<IActionResult> GetAllTasks(int batchId)
        {
            try
            {
                List<UserTask> tasks = await _taskServices.GetAllTasks(batchId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("tasks/{taskId}/subtasks")]
        public async Task<IActionResult> GetAllSubtasks(int taskId)
        {
            try
            {
                List<SubTask> subtasks = await _taskServices.GetAllSubtasks(taskId);
                return Ok(subtasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

         [HttpGet("tasks/search")]
        public async Task<IActionResult> SearchTasksByTaskName(string taskName)
        {
            try
            {
                List<UserTask> tasks = await _taskServices.SearchTasksByTaskName(taskName);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

       [HttpGet("{userId}")]
        public async Task<ActionResult<List<UserTask>>> GetTasksByUserId(int userId)
        {
            var tasks = await _taskServices.GetTasksByUserIdAsync(userId);
            if (tasks == null)
            {
                return NotFound();
            }
            return tasks;
        }

        [HttpGet("subtasks/{subtaskId}/download")]
        public async Task<IActionResult> DownloadSubtaskFile(int subtaskId)
        {
            try
            {
                byte[] fileData = await _taskServices.DownloadSubtaskFile(subtaskId);
                if (fileData == null)
                {
                    return NotFound("File not found");
                }

                // You can adjust the content type and file name as per your file type and naming convention
                return File(fileData, "application/octet-stream", "subtask_file.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

          [HttpGet("{userId}/with-subtasks")]
    public async Task<ActionResult<IEnumerable<UserTask>>> GetTasksWithSubtasksByUserIdAsync(int userId)
    {
        var tasks = await _taskServices.GetTasksWithSubtasksByUserIdAsync(userId);
        if (tasks == null)
        {
            return NotFound();
        }
        return Ok(tasks);
    }

     [HttpGet("tasks/{taskId}/subtask")]
        public async Task<IActionResult> GetSubtaskss(int taskId)
        {
            try
            {
                List<SubTask> subtasks = await _taskServices.GetSubtaskss(taskId);
                return Ok(subtasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


         [HttpGet("Sub/{subtaskId}")]
        public async Task<ActionResult<SubTask>> GetSubtaskById(int subtaskId)
        {
            var subtask = await _taskServices.GetSubtaskByIdAsync(subtaskId);

            if (subtask == null)
                return NotFound();

            return Ok(subtask);
        }

    }
}
