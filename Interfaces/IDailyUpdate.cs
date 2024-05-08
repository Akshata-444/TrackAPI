using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;


namespace TrackAPI.Interfaces
{
    public interface IDailyUpdate
    {
        Task<string> AddDailyUpdateAsync(DailyUpdateDto dailyUpdateDto);

        Task<List<DailyUpdateDto>> GetDailyUpdatesByUserIdAsync(int userId);

    }
}