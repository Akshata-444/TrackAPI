using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using TrackAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 

namespace TrackAPI.Repository
{
    public class AddUserRepo : IUser
    {
          TrackDbContext  context;
         static IConfiguration ? _config;

       
        public AddUserRepo(DbContextOptions<TrackDbContext> options,IConfiguration configuration){
            context=  new TrackDbContext(options);
            _config=configuration;
            }

        public async Task<User> GettUser(int userId)
        {
            return await context.Users.FindAsync(userId);
        }

            public async Task<string> AddUser(ADDUSER user)
        {
            try{
                if(user!=null){
                    //Generate a username
                    string username=user.Name.Substring(0,2)+user.Domain;
                    string password = Convert.ToBase64String(System.Security.Cryptography.RandomNumberGenerator.GetBytes(10)).Substring(0, 11);
//Adding the generateed Username and Password to the existing user
User ab=new User();
ab.UserName=username;
ab.Password=password;
ab.Name=user.Name;
ab.Role=user.Role;
ab.Domain=user.Domain;
ab.JobTitle=user.JobTitle;
ab.Location=user.Location;
ab.Phone=user.Phone;
ab.IsCr=user.IsCr;
ab.Gender=user.Gender;
ab.Doj=user.Doj;
ab.CapgeminiEmailId=user.CapgeminiEmailId;
ab.Grade=user.Gender;
ab.Total_Average_RatingStatus=0;//Default value starts at 0
ab.PersonalEmailId=user.PersonalEmailId;
ab.FinalMentorName=user.FinalMentorName;
ab.DailyUpdates=null;

//Now lets add this to the our db
context.Users.Add(ab);
await context.SaveChangesAsync();
return "User sucessfully added";
                }
                return null;
            }
            catch(Exception e){
                throw;
            }
        }
    }

     
}
