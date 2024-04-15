using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;

namespace TrackAPI.Services
{
    public class AddTaskServices
    {
        private readonly ITask _taskRepository;

        public AddTaskServices(ITask taskRepository)
        {
            _taskRepository = taskRepository;
        }

      
        public async Task<int> AssignTaskToBatch(int batchId, AddTask task)
        {
            return await _taskRepository.AssignTaskToBatch(batchId, task);
        }

        /*public async Task<int> CreateSubTask(int taskId, AddSubTask subTask)
        {
            return await _taskRepository.CreateSubTask(taskId, subTask);
        }*/

        public async Task<string> AddNewSubtask(AddSubTask subtask)
        {
            return await _taskRepository.AddNewSubtask(subtask);
        }

         public async Task<List<UserTask>> GetAllTasks(int batchId)
        {
            return await _taskRepository.GetAllTasks(batchId);
        }

                public async Task<List<SubTask>> GetAllSubtasks(int taskId)
        {
            return await _taskRepository.GetAllSubtasks(taskId);
        }

         public async Task<List<UserTask>> SearchTasksByTaskName(string taskName)
        {
            return await _taskRepository.SearchTasksByTaskName(taskName);
        }

        public async Task<List<UserTask>> GetTasksByUserIdAsync(int userId)
        {
            var tasks = await _taskRepository.GetTasksByUserIdAsync(userId);
            return tasks;
        }
    }

    }

