using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;

namespace TrackAPI.Services
{
    public class AddTaskServices
    {
        public ITask Task;
        public AddTaskServices(ITask Task) {
        this.Task = Task;

    }

     public async Task<string> AddTask(AddTask task)
        {
            try{
                return await Task.AddTask(task);


            }
            catch(Exception ex){
                throw;
            }
            }

}
}