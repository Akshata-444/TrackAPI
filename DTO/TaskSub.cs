using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TrackAPI.Models.TaskSubmission;

namespace TrackAPI.DTO
{
    public class TaskSub
    {
        public int UserId{get;set;}//Fk to user table

        public int subtaskid{get;set;}
        public status status{get;set;}=status.Pending;
        //public string? SubmittedFileName{get;set;}
        public IFormFile? FileUpload{get;set;}//Will always be null

        //public byte[]? FileUploadSubmission { get; set; }
        //public DateTime? SubTaskSubmittedOn { get; set; }//Date of when The Submission file was submitted

    }
}