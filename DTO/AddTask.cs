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
    public priority Priority { get; set; }
    public DateTime DeadLine { get; set; }
    public int Status { get; set; }
    public int AssignedBy { get; set; }
  
    public string Comments { get; set; }
    }
}