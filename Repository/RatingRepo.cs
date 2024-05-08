using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackAPI.Data;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;


namespace TrackAPI.Repository
{
    public class RatingRepo : IRating
    {
       
     private readonly TrackDbContext _context;

        public RatingRepo(TrackDbContext context)
        {
            _context = context;
        }

        public async Task<Rating> AddRatingAsync(AddRating rating)
        {
            var newRating = new Rating
            {
                RatedBy = rating.RatedBy,
                RatedTo = rating.RatedTo,
                TaskSubmissionId = rating.TaskSubmissionId,
                RatingValue = rating.RatingValue,
                Comments = rating.Comments
            };

            _context.Ratings.Add(newRating);
            await _context.SaveChangesAsync();

            return newRating;
        }


         public async Task<IEnumerable<Rating>> GetRatingsByUserIdAsync(int userId)
        {
            return await _context.Ratings
                .Where(r => r.RatedTo == userId)
                .ToListAsync();
        }

        public async Task<int?> GetSubtaskIdBySubmissionIdAsync(int submissionId)
        {
            return await _context.Ratings
                .Where(r => r.TaskSubmissionId == submissionId)
                .Select(r => r.TaskSubmissions.subtaskid)
                .FirstOrDefaultAsync();
        }

        

    }
}