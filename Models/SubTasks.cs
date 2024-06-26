using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAPI.Models
{

        public class SubTask
{
    public int SubTaskId { get; set; }

    //public int UserId { get; set; }//Fk to User
    public string Title { get; set; }
    public string Description { get; set; }

    //public status Status { get; set; }
    public int TaskId { get; set; }//Fk to Task

    public byte[]? FileUploadTaskPdf { get; set; }

     public DateTime CreationDate { get; set; }
   
   
    
    public UserTask? UserTask { get;set; }//Nav Property

    public string? FileName{get;set;}
    }
    }
