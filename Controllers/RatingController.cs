using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.DTO;
using TrackAPI.Models;
using TrackAPI.Services;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    { private readonly RatingServices _ratingService;

        public RatingController(RatingServices ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRating(AddRating ratingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _ratingService.AddRating(ratingDto);

            return Ok(result);
        }

         [HttpGet("{userId}")]
        public async Task<IActionResult> GetRatingsByUserId(int userId)
        {
            var ratings = await _ratingService.GetRatingsByUserId(userId);
            return Ok(ratings);
        }

         [HttpGet("subtask/{submissionId}")]
        public async Task<IActionResult> GetSubtaskIdBySubmissionId(int submissionId)
        {
            var subtaskId = await _ratingService.GetSubtaskIdBySubmissionId(submissionId);
            if (subtaskId == null)
            {
                return NotFound();
            }
            return Ok(subtaskId);
        }
    }
}