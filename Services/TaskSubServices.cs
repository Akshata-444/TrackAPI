using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using static TrackAPI.Models.TaskSubmissions;

namespace TrackAPI.Services
{
    public class TaskSubServices
    {
        private readonly ITaskSub taskrepo;

        public TaskSubServices(ITaskSub taskrepo)
        {
            this.taskrepo = taskrepo;
        }


       /* public async Task<List<int>> GetUsersBySubtaskId(int subtaskId)
        {
            return await taskrepo.GetUsersBySubtaskId(subtaskId);
        }*/




        public async Task<TaskSubmissions> SubmitTask(TaskSub taskSubmission)
        {
            return await taskrepo.SubmitTask(taskSubmission);
        }

      
public async Task<List<(string, byte[])>> GetSubmissionsBySubtaskIdAndUserId(int subtaskId, int TaskSubmissionsId)
        {
            return await taskrepo.GetSubmissionsBySubtaskIdAndUserId(subtaskId, TaskSubmissionsId);
        }

   
 public async Task<List<TaskSubmissions>> GetSubmissionsBySubtaskIdAsync(int subtaskId)
        {
            return await taskrepo.GetSubmissionsBySubtaskIdAsync(subtaskId);
        }

    }
}