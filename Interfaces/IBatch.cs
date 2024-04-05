using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrackAPI.DTO;
using TrackAPI.Models;

namespace TrackAPI.Interfaces
{
    public interface IBatch
    {
        Task<string> AddUsersFromExcel(byte[] excelData);
        //Task<string> AddUserWithBatch(AddBatch batchs);
        Task<string> AddBatchWithEmployeesFromExcel(AddBatch batch);

        Task<IEnumerable<Batch>> GetAllBatches();

    }
}