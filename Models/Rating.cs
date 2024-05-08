using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TrackAPI.Models.TaskSubmissions;

namespace TrackAPI.Models
{
    
     

    
    public class Rating
    {
     

    public long RatingId { get; set; }
    public int RatedBy { get; set; }//Fk to user (Mentor id)
    public int RatedTo { get; set; }//Fk to user id(Employee)
    //add subtaskid
    public int TaskSubmissionId { get; set; }//Fk to submission table
    public int RatingValue { get; set; }
    //make it string
    public string? Comments { get; set; }//Average,Very Good,Average,Below Good, =>Make the enum
   
   //make all nullable
    public int? FeedbackId { get; set; }//Fk to Feedback table
    public FeedBack FeedBack { get;set; }//Nav Property
//comment tasksub 
//add public subtask subtask
        public TaskSubmissions TaskSubmissions { get;  set; }//Nav Property
        public User RatedByUser { get;  set; }//Nav Property
        public User RatedToUser { get; set; }//Nav Property
    }
    }


 