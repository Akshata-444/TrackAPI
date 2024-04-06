using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrackAPI.DTO;
using TrackAPI.Models;
using TrackAPI.Services;

namespace TrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatchController : ControllerBase
    {
        private readonly BatchServices _batchService;

        public BatchController(BatchServices batchService)
        {
            _batchService = batchService;
        }


       /*[HttpPost("upload-users")]
        //[Route(AddUsersFromExcel)]
       [Consumes("multipart/form-data")]
       // [SwaggerOperation(Summary = "Upload users from Excel file")]
        public async Task<IActionResult> AddUsersFromExcel(IFormFile excelFile)
        {
            try
            {
                if (excelFile == null || excelFile.Length == 0)
                {
                    return BadRequest("No file uploaded");
                }

                string result = await _batchService.AddUsersFromExcel(excelFile);

                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }*/
       
       
    

//Ansika

/*
[HttpPost("AddBatch")]
        [Consumes("multipart/form-data")]
public async Task<IActionResult> AddUserWithBatch([FromForm] AddBatch batch)
{
    try
    {
        var res =await _batchService.AddUserWithBatch(batch);
        if(res==null)
        {
            return BadRequest();
        }
        return Ok("Batch And Users Added Successfully.");
    }
    catch(Exception ex){
        return StatusCode(500,"Ann Error Occured while processing thr file");

    }
}
*/





       [HttpPost("upload-users")]
        //[Route(AddUsersFromExcel)]
       [Consumes("multipart/form-data")]
// [SwaggerOperation(Summary = "Upload users from Excel file")]
public async Task<IActionResult> AddUsersFromExcel( IFormFile file)
{
    try
    {
        if (file == null || file.Length == 0)
            return BadRequest("Excel file is not selected.");
 
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
 
            var result = await _batchService.AddUsersFromExcel(memoryStream.ToArray());
            return Ok(result);
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex}");
    }
}
    
     [HttpPost("add-batch-with-employees")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddBatchWithEmployeesFromExcel([FromForm] AddBatch batch)
        {
            try
            {
                if (batch.Employee_info_Excel_File == null || batch.Employee_info_Excel_File.Length == 0)
                    return BadRequest("Employee Excel file is not selected.");
                    var result = await _batchService.AddBatchWithEmployeesFromExcel(batch);
                    return Ok(result);
                /*using (var memoryStream = new MemoryStream())
                {
                    await batch.Employee_info_Excel_File.CopyToAsync(memoryStream);
                    batch.Employee_info_Excel_File.Position = 0; // Reset the stream position

                    var result = await _batchService.AddBatchWithEmployeesFromExcel(batch);
                    return Ok(result);
                }*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetAllBatches()
        {
            var batches = await _batchService.GetAllBatches();
            return Ok(batches);
        }

         [HttpDelete("{batchId}")]
        public async Task<IActionResult> DeleteBatch(int batchId)
        {
            try
            {
                var result = await _batchService.DeleteBatch(batchId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
