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
        private readonly IRating rating;

        public RatingServices(IRating rating)
        {
            this.rating = rating;
        }

        public async Task<Rating> AddRating(AddRating ratingDto)
        {
            return await rating.AddRating(ratingDto);
        }


    }
}