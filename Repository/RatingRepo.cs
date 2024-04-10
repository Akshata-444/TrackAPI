using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Rating> AddRating(AddRating ratingDto)
        {
            var rating = new Rating
            {
                RatedBy = ratingDto.RatedBy,
                RatedTo = ratingDto.RatedTo,
                TaskSubmissionId = ratingDto.TaskSubmissionId,
                RatingValue = ratingDto.RatingValue,
                Comments = ratingDto.Comments
            };

            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            return rating;
        }

    }
}