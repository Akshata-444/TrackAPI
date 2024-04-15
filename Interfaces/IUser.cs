using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAPI.DTO;
using TrackAPI.Models;

namespace TrackAPI.Interfaces
{
    public interface IUser
    {
        Task<string> AddUser(ADDUSER user);

         Task<User> GettUser(int userId);
    }
}