using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.Models;
using TrackAPI.Interfaces;
using TrackAPI.Repository;
using TrackAPI.DTO;

namespace TrackAPI.Services
{
    public class ADDUSERServices
    {
        public IUser User;
        public ADDUSERServices(IUser User) {
        this.User = User;

    }

    public async Task<string> AddUser(ADDUSER user)
        {
            try{
                return await User.AddUser(user);


            }
            catch(Exception ex){
                throw;
            }
            }
}}