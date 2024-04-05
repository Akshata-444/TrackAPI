using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAPI.Models
{

        public class SubTask
{
    public int SubTaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int TaskId { get; set; }//Fk to Task
    public byte[] FileUploadSubmission { get; set; }
    public DateTime? FileUploadDate { get; set; }
    public byte[] FileUploadTaskPdf { get; set; }
    public DateTime CreationDate { get; set; }
    public UserTask UserTask { get;set; }//Nav Property
    }
    }
