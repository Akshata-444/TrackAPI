using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Models;

namespace TrackAPI.DTO
{
    public class AddTask
    {
    public string TaskName { get; set; }
    public string Description { get; set; }
    public long Priority { get; set; }
    public DateTime DeadLine { get; set; }
    public string Status { get; set; }
    public int AssignedBy { get; set; }
    public int AssignedTo { get; set; }
    public long Comments { get; set; }
    public DateTime CreatedAt { get; set; }


    }
}