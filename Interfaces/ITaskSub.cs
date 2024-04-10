using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Models;
using static TrackAPI.Models.TaskSubmission;

namespace TrackAPI.Interfaces
{
    public interface ITaskSub
    {
         Task<TaskSubmissions> SubmitTask(TaskSub taskSubmission);

         Task<List<byte[]>> GetSubmissionsBySubtaskId(int subtaskId);

         
    }
}