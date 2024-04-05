using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Interfaces;
using TrackAPI.Repository;
using TrackAPI.Models;
using TrackAPI.DTO;


namespace TrackAPI.Services
{
    public class LoginService
    {

     public ILogin User;
        public LoginService(ILogin log) {
        this.User = log;
    }

     public async Task<string> LoginUser(Login user){

     try
     {
        
         return await User.LoginUser(user);
     }
     catch(Exception ex) {
         throw;
     }
 }
}
}