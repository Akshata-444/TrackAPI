using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Models;

namespace TrackAPI.Interfaces
{
    public interface ITask
    {
       Task<int> AssignTaskToBatch(int batchId, AddTask task);

       //Task<int> CreateSubTask(int taskId, AddSubTask subTask);
      Task<string> AddNewSubtask(AddSubTask subtask);

      Task<List<UserTask>> GetAllTasks(int batchId);

      Task<List<SubTask>> GetAllSubtasks(int taskId);

      Task<List<UserTask>> SearchTasksByTaskName(string taskName);


       
    }
}