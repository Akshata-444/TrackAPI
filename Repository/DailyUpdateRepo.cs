using System;
using System.Threading.Tasks;
using TrackAPI.Data;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TrackAPI.Repository
{
    public class DailyUpdateRepo : IDailyUpdate
    {
        private readonly TrackDbContext _context;

        public DailyUpdateRepo(TrackDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddDailyUpdateAsync(DailyUpdateDto dailyUpdateDto)
        {
            try
            {
                var dailyUpdate = new DailyUpdate
                {
                    UserId = dailyUpdateDto.UserId,
                    Title = dailyUpdateDto.Title,
                    UploadedAt = dailyUpdateDto.UploadedAt,
                    LearnedToday = dailyUpdateDto.LearnedToday,
                    PlanForTomorrow = dailyUpdateDto.PlanForTomorrow,
                    Challenge = dailyUpdateDto.Challenge,
                    OneDriveLink = dailyUpdateDto.OneDriveLink,
                    Summary = dailyUpdateDto.Summary
                };

                _context.DailyUpdates.Add(dailyUpdate);
                await _context.SaveChangesAsync();

                return "Daily update added successfully";
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as required
                return $"Failed to add daily update: {ex.Message}";
            }
        }


          public async Task<List<DailyUpdateDto>> GetDailyUpdatesByUserIdAsync(int userId)
        {
            var dailyUpdates = await _context.DailyUpdates
                .Where(du => du.UserId == userId)
                .Select(du => new DailyUpdateDto
                {
                    UserId = du.UserId,
                    Title = du.Title,
                    UploadedAt = du.UploadedAt,
                    LearnedToday = du.LearnedToday,
                    PlanForTomorrow = du.PlanForTomorrow,
                    Challenge = du.Challenge,
                    OneDriveLink = du.OneDriveLink,
                    Summary = du.Summary
                })
                .ToListAsync();

            return dailyUpdates;
        }
    }
}