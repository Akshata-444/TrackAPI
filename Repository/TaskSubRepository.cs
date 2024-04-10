using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using Microsoft.EntityFrameworkCore;
using TrackAPI.DTO;
using TrackAPI.Data;
using static TrackAPI.Models.TaskSubmission;
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

        public async Task<TaskSubmissions> SubmitTask(TaskSub taskSubmission)
        {
            var submission = new TaskSubmissions
            {
                UserId = taskSubmission.UserId,
                subtaskid = taskSubmission.subtaskid,
                status = taskSubmission.status,
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

        public async Task<List<byte[]>> GetSubmissionsBySubtaskId(int subtaskId)
        {
            var submissions = await _context.TaskSubmissions
                .Where(s => s.subtaskid == subtaskId && s.FileUploadSubmission != null)
                .Select(s => s.FileUploadSubmission)
                .ToListAsync();

            return submissions;
        }


    }}
