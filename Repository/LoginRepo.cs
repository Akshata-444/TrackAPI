using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text; // Add this using directive
using TrackAPI.Data;
using TrackAPI.DTO;
using TrackAPI.Interfaces;
using TrackAPI.Models;
using TrackAPI.Services;


namespace TrackAPI.Repository
{
    public class LoginRepo : ILogin
    {
         TrackDbContext  context;
         static IConfiguration ? _config;

       
        public LoginRepo(DbContextOptions<TrackDbContext> options,IConfiguration configuration){
            context=  new TrackDbContext(options);
            _config=configuration;
            }

        public static string GenerateToken(User user)
        {
            // Create claims for the user
            var claims = new List<Claim>{
            
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("userId", user.UserId.ToString()) 
            };
            // Create a security key based on the configured JWT key
             var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
     // Create signing credentials using the security key
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

// Create a JWT token with issuer, audience, claims, expiration, and signing credentials
    var token = new JwtSecurityToken(
        _config["Jwt:Issuer"],
        _config["Jwt:Audience"],
        claims,
        expires: DateTime.Now.AddHours(1),
        signingCredentials: credentials
    );
     // Write the token as a string and return it
  return new JwtSecurityTokenHandler().WriteToken(token);

  }
        



        public async Task<string> LoginUser(Login user)
        {
             try{
                if(user!=null){
                    // Check if the user exists in the database
                    var existing_user=context.Users.FirstOrDefault(s=>s.UserName==user.UserName && s.Password==user.Password);
                 // Generate a JWT token for the authenticated user
                if(existing_user!=null){string Token=GenerateToken(existing_user);
                    //Adding that to Json response containing the token
                    var responseJson = new
                {
                    token = Token,
                    userId = existing_user.UserId
                    //userProfile = existing_user
                };
                // Serialize the JSON response to a string and return it
                  string jsonResponse = JsonConvert.SerializeObject(responseJson);
                return jsonResponse;
}
                }
                return null;
            }
            catch(Exception e){
                throw;
            }
        }


        }

}



    
