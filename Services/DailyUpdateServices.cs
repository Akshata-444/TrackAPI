using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;

namespace TrackAPI.Services
{
    public class DailyUpdateService
    {  
        private readonly IDailyUpdate _dailyUpdateRepository;

        public DailyUpdateService(IDailyUpdate dailyUpdateRepository)
        {
            _dailyUpdateRepository = dailyUpdateRepository;
        }

        public async Task<string> AddDailyUpdateAsync(DailyUpdateDto dailyUpdateDto)
        {
            return await _dailyUpdateRepository.AddDailyUpdateAsync(dailyUpdateDto);
        }

         public async Task<List<DailyUpdateDto>> GetDailyUpdatesByUserIdAsync(int userId)
        {
            return await _dailyUpdateRepository.GetDailyUpdatesByUserIdAsync(userId);
        }
    }

}
