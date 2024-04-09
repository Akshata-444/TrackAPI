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
    }
}
