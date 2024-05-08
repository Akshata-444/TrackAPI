using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackAPI.DTO;
using TrackAPI.Services;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyUpdateController : ControllerBase
    {

         private readonly DailyUpdateService _dailyUpdateService;

        public DailyUpdateController(DailyUpdateService dailyUpdateService)
        {
            _dailyUpdateService = dailyUpdateService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDailyUpdateAsync([FromBody] DailyUpdateDto dailyUpdateDto)
        {
            try
            {
                string result = await _dailyUpdateService.AddDailyUpdateAsync(dailyUpdateDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetDailyUpdatesByUserIdAsync(int userId)
        {
            try
            {
                var dailyUpdates = await _dailyUpdateService.GetDailyUpdatesByUserIdAsync(userId);
                return Ok(dailyUpdates);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}