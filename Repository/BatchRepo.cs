using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using OfficeOpenXml;
using TrackAPI.Data;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.Data.SqlClient;

namespace TrackAPI.Repository
{
    public class BatchRepo : IBatch

    {
        private readonly TrackDbContext context;

        public BatchRepo(TrackDbContext context)
        {
            this.context = context;
        }

public async Task<string> AddUsersFromExcel(byte[] excelData)
{
     try
     {
         using (var stream = new MemoryStream(excelData))
         {
             using (var package = new ExcelPackage(stream))
             {
                 ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet
                 ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                 int rowCount = worksheet.Dimension.Rows;
 
                 List<ADDUSER> users = new List<ADDUSER>();
                 for (int row = 2; row <= rowCount; row++) // Assuming the first row contains headers
                 {
                     ADDUSER user = new ADDUSER
                     {
                        Name=worksheet.Cells[row, 5].Value?.ToString(),
                       
                   // UserName=worksheet.Cells[row, 2].Value?.ToString(),
                   // Password=worksheet.Cells[row, 3].Value?.ToString(),
                   // Role= Enum.TryParse<Role>(worksheet.Cells[row, 4].Value?.ToString(), out var parsedRole) ? parsedRole : default(Role),
                    Domain=worksheet.Cells[row, 14].Value?.ToString(),
                    JobTitle=worksheet.Cells[row, 10].Value?.ToString(),
                    Location=worksheet.Cells[row, 11].Value?.ToString(),
 
                    Phone=worksheet.Cells[row, 22].Value?.ToString(),
                    //IsCr=Convert.ToBoolean(worksheet.Cells[row, 9].Value?.ToString()),
                    Gender=worksheet.Cells[row, 6].Value?.ToString(),
                    Doj=Convert.ToDateTime(worksheet.Cells[row, 7].Value?.ToString()),
                    CapgeminiEmailId=worksheet.Cells[row, 23].Value?.ToString(),
 
                    Grade=worksheet.Cells[row,9].Value?.ToString(),
                   // Total_Average_RatingStatus=Convert.ToDouble(worksheet.Cells[row, 14].Value?.ToString()),
                    PersonalEmailId=worksheet.Cells[row, 21].Value?.ToString(),
                   // EarlierMentorName=worksheet.Cells[row, 16].Value?.ToString(),
                   // FinalMentorName=worksheet.Cells[row, 17].Value?.ToString(),
                   // Attendance_Count=Convert.ToDouble(worksheet.Cells[row, 18].Value?.ToString())
 
 
                         //   Password = Convert.ToInt32(worksheet.Cells[row, 5].Value), // Assuming RoleId is int
                         //   BatchId = Convert.ToInt32(worksheet.Cells[row, 6].Value) // Assuming BatchId is int
                     };
 
                     users.Add(user);
                 }
 
                 // Add users to the database
                 context.Users.AddRange(users.Select(u => new User
                 {
                    Name=u.Name,
                    UserName=GenerateUserName(u.Name,u.Domain),
                    Password=GeneratePassword(),
                    Role=0,
                    Domain=u.Domain,
                    JobTitle=u.JobTitle,
                    Location=u.Location,
 
                    Phone=u.Phone,
                    IsCr=false,
                    Gender=u.Gender,
                    Doj=u.Doj,
                    CapgeminiEmailId=u.CapgeminiEmailId,
 
                    Grade=u.Grade,
                    Total_Average_RatingStatus=0,
                    PersonalEmailId=u.PersonalEmailId,
                    Attendance_Count=0
                 }));
                 await context.SaveChangesAsync();

 
                 return "Employee added successfully.";
             }
         }
 
     }
     catch (Exception ex)
     {
         return $"Error occurred while adding users: {ex.Message}. Inner Exception: {ex.InnerException?.Message}";
     }

     
}




    public string GenerateUserName(string name,string domain)
     {

         string username=name.Substring(0,2)+domain;
        return  username;
     }

     public string GeneratePassword()
     {
       string password = Convert.ToBase64String(System.Security.Cryptography.RandomNumberGenerator.GetBytes(10)).Substring(0, 11);

        return password;
     }

  public async Task<string> AddBatchWithEmployeesFromExcel(AddBatch batch)
        {
            try
            {
                // Create new Batch instance
                Batch newBatch = new Batch
                {
                    MentorId = batch.MentorId,
                    BatchName = batch.BatchName,
                    Domain = batch.Domain,
                    Description = batch.Description
                };
                 byte[] fileData;
                 using (var memoryStream = new MemoryStream())
                 {
                    await batch.Employee_info_Excel_File.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                 }
                // Read employee Excel file and store it as byte array
                newBatch.Employee_info_Excel =fileData;

                // Save the batch to the database
                context.Batches.Add(newBatch);
                await context.SaveChangesAsync();

                // Add users from the Excel file to the User table
                await AddUsersFromExcelfile(fileData,newBatch);

                return "Batch and employees added successfully.";
            }
            catch (Exception ex)
            {
                return $"Error occurred while adding batch and employees: {ex.Message}. Inner Exception: {ex.InnerException?.Message}";
            }
        }

        private async Task AddUsersFromExcelfile(byte[] fileData,Batch newBatch)
        {
             using (var memoryStream = new MemoryStream(fileData))
             {

            
            using (var package = new ExcelPackage(memoryStream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                int rowCount = worksheet.Dimension.Rows;

                List<User> users = new List<User>();
                for (int row = 2; row <= rowCount; row++) // Assuming the first row contains headers
                {
                    User user = new User
                    {
                        // Populate user properties from Excel columns
                      Name = worksheet.Cells[row, 5].Value?.ToString(),
                      Domain=worksheet.Cells[row, 14].Value?.ToString(),
                     JobTitle=worksheet.Cells[row, 10].Value?.ToString(),
                     Location=worksheet.Cells[row, 11].Value?.ToString(),
 
                     Phone=worksheet.Cells[row, 22].Value?.ToString(),
                    //IsCr=Convert.ToBoolean(worksheet.Cells[row, 9].Value?.ToString()),
                    Gender=worksheet.Cells[row, 6].Value?.ToString(),
                    Doj=Convert.ToDateTime(worksheet.Cells[row, 7].Value?.ToString()),
                    CapgeminiEmailId=worksheet.Cells[row, 23].Value?.ToString(),
 
                    Grade=worksheet.Cells[row,9].Value?.ToString(),
                    PersonalEmailId=worksheet.Cells[row, 21].Value?.ToString(),
                        // Add other properties as needed
                    };

                    users.Add(user);
                }

              foreach(var user in users)
         {
         user.Batches = new List<Batch>(){newBatch};
         }
                // Add users to the User table
               // context.Users.AddRange(users);
               context.Users.AddRange(users.Select(u => new User
                 {
                    Name=u.Name,
                    UserName=GenerateUserName(u.Name,u.Domain),
                    Password=GeneratePassword(),
                    Role=0,
                    Domain=u.Domain,
                    JobTitle=u.JobTitle,
                    Location=u.Location,
 
                    Phone=u.Phone,
                    IsCr=false,
                    Gender=u.Gender,
                    Doj=u.Doj,
                    CapgeminiEmailId=u.CapgeminiEmailId,
 
                    Grade=u.Grade,
                    Total_Average_RatingStatus=0,
                    PersonalEmailId=u.PersonalEmailId,
                    //EarlierMentorName=u.EarlierMentorName,
                    //FinalMentorName=u.FinalMentorName,
                    Attendance_Count=0,
                    Batches=u.Batches
                 }));
                
               
                await context.SaveChangesAsync();
            }
             }
        }

        private async Task<byte[]> ReadExcelFileToByteArray(Stream excelStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await excelStream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }  

         public async Task<IEnumerable<Batch>> GetAllBatches()
        {
            return await context.Batches.ToListAsync();
        }

       public async Task<bool> DeleteBatchAsync(int batchId)
        {
            try
            {
                var batch = await context.Batches.FindAsync(batchId);
                if (batch == null)
                    return false;

                context.Batches.Remove(batch);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }


    

        public async Task<string> GetExcelDataForBatch(int batchId)
{
    var batch = await context.Batches.FindAsync(batchId);
    if (batch == null || batch.Employee_info_Excel == null)
        return null;

    using (var stream = new MemoryStream(batch.Employee_info_Excel))
    {
        using (var package = new ExcelPackage(stream))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            int rowCount = worksheet.Dimension.Rows;

            // Create a StringBuilder to store the data
            StringBuilder excelData = new StringBuilder();

            // Iterate through rows and columns to read Excel data
            for (int row = 1; row <= rowCount; row++)
            {
                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    // Append cell value to StringBuilder
                    excelData.Append(worksheet.Cells[row, col].Value?.ToString() ?? string.Empty);
                    excelData.Append("\t"); // Add tab as a delimiter between columns
                }
                excelData.AppendLine(); // Move to the next row
            }

            return excelData.ToString();
        }
    }
}



 public async Task<bool> UpdateBatchAsync(int batchId, Batch updatedBatch)
        {
            try
            {
                var batch = await context.Batches.FindAsync(batchId);
                if (batch == null)
                    return false;

                batch.BatchName = updatedBatch.BatchName;
                batch.Domain = updatedBatch.Domain;
                batch.Description = updatedBatch.Description;

                context.Entry(batch).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }
}

