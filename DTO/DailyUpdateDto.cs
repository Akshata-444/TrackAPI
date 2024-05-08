using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Models;

namespace TrackAPI.DTO
{
    public class DailyUpdateDto
    {
         public int UserId { get; set; }
    public string Title { get; set; }
    public DateTime UploadedAt { get; set; }
    public string LearnedToday { get; set; }
   public string PlanForTomorrow { get; set; }
    public string Challenge { get; set; }
    public string OneDriveLink { get; set; }
    public string Summary { get; set; }


    }
}