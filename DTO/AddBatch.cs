using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Models;

namespace TrackAPI.DTO
{
    public class AddBatch
    {
        public int MentorId { get; set; } // FK to UserID

         public string BatchName { get; set; }//System generated using the Date_of_creation+MentorName+Domain
        public string Domain { get; set; }
        public string Description { get; set; }

       // public byte[]? Employee_info_Excel { get; set; }

        public IFormFile? Employee_info_Excel_File { get; set; } // File field for file uploads
        // File field for file uploads
        // This field will later be used to add new Users(role=Employee) and be stored in a byte[] stream.
    }
}
