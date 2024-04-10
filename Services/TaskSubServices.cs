using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using static TrackAPI.Models.TaskSubmission;

namespace TrackAPI.Services
{
    public class TaskSubServices
    {
        private readonly ITaskSub taskrepo;

        public TaskSubServices(ITaskSub taskrepo)
        {
            this.taskrepo = taskrepo;
        }

        public async Task<TaskSubmissions> SubmitTask(TaskSub taskSubmission)
        {
            return await taskrepo.SubmitTask(taskSubmission);
        }

                public async Task<List<byte[]>> GetSubmissionsBySubtaskId(int subtaskId)
        {
            return await taskrepo.GetSubmissionsBySubtaskId(subtaskId);
        }



    }
}