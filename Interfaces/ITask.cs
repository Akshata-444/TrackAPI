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
      
      Task<List<UserTask>> GetTasksByUserIdAsync(int userId);

      Task<byte[]> DownloadSubtaskFile(int subtaskId);

         Task<bool> DeleteTask(int taskId);

          Task<bool> DeleteSubTaskAsync(int subTaskId);

           Task<IEnumerable<UserTask>> GetTasksWithSubtasksByUserIdAsync(int userId); 

           Task<List<SubTask>> GetSubtaskss(int taskId);

           Task<SubTask> GetSubtaskByIdAsync(int subtaskId);


    }
}