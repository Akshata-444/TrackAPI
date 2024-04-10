using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackAPI.Data;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using Microsoft.EntityFrameworkCore;
using TrackAPI.DTO;
using static TrackAPI.Models.TaskSubmission;


namespace TrackAPI.Repository
{
    public class AddTaskRepo : ITask
    {
        private readonly TrackDbContext _context;

        public AddTaskRepo(TrackDbContext context)
        {
            _context = context;
        }

         public async Task<int> AssignTaskToBatch(int batchId, AddTask task)
        {
            // Get employees in the batch
            var batch = await _context.Batches
                .Include(b => b.Employees)
                .SingleOrDefaultAsync(b => b.BatchId == batchId);

            if (batch == null)
            {
                throw new InvalidOperationException("Batch not found");
            }

            // Create the task
            var userTask = new UserTask
            {
                // ... (Map properties from task DTO)
                TaskName = task.TaskName,
                Description = task.Description,
                Priority = task.Priority,
                DeadLine = task.DeadLine,
                Status = (TrackAPI.Models.TaskSubmission.status)task.Status,
                AssignedBy = task.AssignedBy,
                AssignedTo = batch.Employees.Select(e => e.UserId).ToList(),
                // ... (Other properties)
                BatchId = batchId,
                Comments = task.Comments
            };

            _context.Tasks.Add(userTask);
            await _context.SaveChangesAsync();

            return userTask.UserTaskID;
        }

        public async Task<string> AddNewSubtask(AddSubTask subtask)
        {
            var existingTask = await _context.Tasks.FindAsync(subtask.TaskId);
            if (existingTask == null)
                return "Task not found";

            var newSubtask = new SubTask
            {
                Title = subtask.Title,
                Description = subtask.Description,
                TaskId = subtask.TaskId,
                CreationDate = DateTime.Now,
            FileName = subtask.FileUploadTaskFileUpload.FileName // Assuming FileName is provided in DTO
                        };

                        // Handle file upload logic
                        if (subtask.FileUploadTaskFileUpload != null && subtask.FileUploadTaskFileUpload.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                subtask.FileUploadTaskFileUpload.CopyTo(ms);
                                newSubtask.FileUploadTaskPdf = ms.ToArray();
                            }
                        }

            _context.SubTask.Add(newSubtask);
            await _context.SaveChangesAsync();

            return "Subtask created successfully";
        }

        public async Task<List<UserTask>> GetAllTasks(int batchId)
        {
            // Retrieve all tasks for a batch
            return await _context.Tasks.Where(t => t.BatchId == batchId).ToListAsync();
        }

        /*public async Task<List<SubTask>> GetAllSubtasks(int taskId)
        {
            return await _context.SubTask.Where(s => s.TaskId == taskId).ToListAsync();
        }*/

        public async Task<List<SubTask>> GetAllSubtasks(int taskId)
        {
            // Retrieve all subtasks for a task
            return await _context.SubTask.Where(s => s.TaskId == taskId).ToListAsync();
        }

         public async Task<List<UserTask>> SearchTasksByTaskName(string taskName)
        {
            return await _context.Tasks.Where(t => t.TaskName.Contains(taskName)).ToListAsync();
        }

       


    }}