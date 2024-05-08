using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using Microsoft.EntityFrameworkCore;
using TrackAPI.DTO;
using TrackAPI.Data;
using static TrackAPI.Models.TaskSubmissions;
using System.Data;

namespace TrackAPI.Repository
{
    public class TaskSubRepository : ITaskSub
    {

    private readonly TrackDbContext _context;

        public TaskSubRepository(TrackDbContext context)
        {
            _context = context;
        }
         


/*public async Task<List<int>> GetUsersBySubtaskId(int subtaskId)
{
    var userIds = await _context.TaskSubmissions
        .Where(s => s.subtaskid == subtaskId && s.FileUploadSubmission != null)
        .Select(s => s.UserId)
        .Distinct()
        .ToListAsync();

    return userIds;
}*/

  public async Task<byte[]> DownloadSubmission(int subtaskId, int submissionId)
        {
            var submission = await _context.TaskSubmissions
                .FirstOrDefaultAsync(s => s.subtaskid == subtaskId && s.TaskSubmissionsId == submissionId && s.FileUploadSubmission != null);

            if (submission == null)
            {
                return null;
            }

            return submission.FileUploadSubmission;
        }


    

   public async Task<List<TaskSubmissions>> GetSubmissionsBySubtaskIdAsync(int subtaskId)
        {
            var result = await _context.TaskSubmissions.Where(ts => ts.subtaskid == subtaskId).ToListAsync();

                return result;
        }



        public async Task<List<(string, byte[])>> GetSubmissionsBySubtaskIdAndUserId(int subtaskId, int TaskSubmissionsId)
        {
            var submissions = await _context.TaskSubmissions
                .Where(s => s.subtaskid == subtaskId && s.TaskSubmissionsId == TaskSubmissionsId && s.FileUploadSubmission != null)
                .Select(s => new { s.submittedFileName, s.FileUploadSubmission })
                .ToListAsync();

            var submissionData = submissions
                .Select(s => (s.submittedFileName ?? "", s.FileUploadSubmission))
                .ToList();
            return submissionData;
            //return submissions;
        }
        public async Task<TaskSubmissions> SubmitTask(TaskSub taskSubmission)
        {

             var existingSubmission = await _context.TaskSubmissions
        .FirstOrDefaultAsync(s => s.UserId == taskSubmission.UserId && s.subtaskid == taskSubmission.subtaskid);

    // If a submission already exists, return an error or handle it as needed
    if (existingSubmission != null)
    {
        // You can return an error response or throw an exception here
        // For example:
        throw new InvalidOperationException("You have already submitted the task for this subtask.");
    }
            var submission = new TaskSubmissions
            {
                UserId = taskSubmission.UserId,
                subtaskid = taskSubmission.subtaskid,
                status = status.Completed,
                submittedFileName = taskSubmission.FileUpload.FileName,
                SubTaskSubmitteddOn = DateTime.Now,
                FileUploadSubmission = taskSubmission.FileUpload != null 
                                        ? ConvertToByteArray(taskSubmission.FileUpload) 
                                        : null
            };

            await _context.TaskSubmissions.AddAsync(submission);
            await _context.SaveChangesAsync();

            return submission;
        }

        private byte[] ConvertToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }

   

    
    }
