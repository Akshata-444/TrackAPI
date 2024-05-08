using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.DTO;
using TrackAPI.Models;
using static TrackAPI.Models.TaskSubmissions;

namespace TrackAPI.Interfaces
{
    public interface ITaskSub
    {
         Task<TaskSubmissions> SubmitTask(TaskSub taskSubmission);

         
         Task<List<TaskSubmissions>> GetSubmissionsBySubtaskIdAsync(int subtaskId);
          
          

         //Task<List<int>> GetUsersBySubtaskId(int subtaskId);

        Task<List<(string, byte[])>> GetSubmissionsBySubtaskIdAndUserId(int subtaskId, int TaskSubmissionsId);

       
       

        

         
    }
}