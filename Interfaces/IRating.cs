using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Models;

namespace TrackAPI.Interfaces
{
    public interface IRating
    {
        Task<Rating> AddRatingAsync(AddRating rating); 

        Task<IEnumerable<Rating>> GetRatingsByUserIdAsync(int userId); 
    
       Task<int?> GetSubtaskIdBySubmissionIdAsync(int submissionId);
    }
}