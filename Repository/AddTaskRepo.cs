using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Models;
using TrackAPI.DTO;
using TrackAPI.Data;
using Microsoft.EntityFrameworkCore;
using TrackAPI.Interfaces;

namespace TrackAPI.Repository
{
    public class AddTaskRepo : ITask
    {
        
            TrackDbContext  context;
         static IConfiguration ? _config;

       
        public AddTaskRepo(DbContextOptions<TrackDbContext> options,IConfiguration configuration){
            context=  new TrackDbContext(options);
             _config=configuration;
        }
        
        

        public async Task<string> AddTask(AddTask task)
        {
            try
            {
                // Map DTO to entity
                UserTask taskEntity = new UserTask();
               // var taskEntity = new Task();
                
                    taskEntity.TaskName = task.TaskName;
                    //TaskName = task.TaskName;
                    taskEntity.Description = task.Description;
                    taskEntity.Priority = task.Priority;
                    taskEntity.DeadLine = task.DeadLine;
                    taskEntity.Status = task.Status;
                    taskEntity.AssignedBy = task.AssignedBy;
                    taskEntity.AssignedTo = task.AssignedTo;
                    taskEntity.Comments = task.Comments;
                    taskEntity.CreatedAt = task.CreatedAt;
                

                // Add entity to DbContext and save changes
               context.Tasks.Add(taskEntity);

               await context.SaveChangesAsync();
               return "Task sucessfully added";
                
                return null;
        }
            
            catch(Exception e){
                throw;
            }
        }
        }
        
}