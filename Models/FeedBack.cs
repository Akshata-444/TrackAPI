using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TrackAPI.Models.Rating;

namespace TrackAPI.Models
{
    public class FeedBack
    {
    
    //
   public int FeedbackId { get; set; }
    public int TaskId { get; set; }
    //add tasksubmission
    public int TotalAverageRating { get; set; }

    //makwe stribg
    public string? Comments { get; set; }
//make all nullable
    public int UserId { get; set; }
    public UserTask? UserTask { get; set; } // Navigation property for Task
    public User? User { get; set; } // Navigation property for User
    public List<Rating>? Ratings { get; set; } // Navigation property for Ratings
}
    }
