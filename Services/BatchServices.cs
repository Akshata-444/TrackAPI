using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;

namespace TrackAPI.Services
{
    public class BatchServices
    {
        private readonly IBatch Batch;

        public BatchServices(IBatch Batch)
        {
            this.Batch = Batch;
        }

        public async Task<string> AddUsersFromExcel(byte[] excelData)
        {
            try
            {
                return await Batch.AddUsersFromExcel(excelData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

         public async Task<string> AddBatchWithEmployeesFromExcel(AddBatch batch)
        {
            try
            {
                return await Batch.AddBatchWithEmployeesFromExcel(batch);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw;
            }
        }


       /* public async Task<string>AddUserWithBatch(AddBatch batch)
        {
            try
            {
                return await Batch.AddUserWithBatch(batch);

            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error occured while saving the file"+ex.Message);
                if(ex.InnerException!=null)
                {
                    Console.WriteLine("Inner Exception:2"+ex.InnerException.Message);
                }
                throw;
            }
        }*/

        public async Task<IEnumerable<Batch>> GetAllBatches()
        {
            return await Batch.GetAllBatches();
        }

         public async Task<bool> DeleteBatchAsync(int batchId)
        {
            return await Batch.DeleteBatchAsync(batchId);
        }

       public async Task<string> GetExcelDataForBatch(int batchId)
{
    return await Batch.GetExcelDataForBatch(batchId);
}
  public async Task<bool> UpdateBatchAsync(int batchId, Batch updatedBatch)
        {
            return await Batch.UpdateBatchAsync(batchId, updatedBatch);
        }

    }
}