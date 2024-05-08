using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;


namespace TrackAPI.Services
{
    public class RatingServices
    {
        private readonly IRating _ratingRepository;

        public RatingServices(IRating ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<Rating> AddRating(AddRating ratingDto)
        {
            return await _ratingRepository.AddRatingAsync(ratingDto);
        }


         public async Task<IEnumerable<Rating>> GetRatingsByUserId(int userId)
        {
            return await _ratingRepository.GetRatingsByUserIdAsync(userId);
        }

        public async Task<int?> GetSubtaskIdBySubmissionId(int submissionId)
        {
            return await _ratingRepository.GetSubtaskIdBySubmissionIdAsync(submissionId);
        }
    }
}

