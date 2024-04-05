using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using TrackAPI.DTO;
using TrackAPI.Models;

namespace TrackAPI.Interfaces
{
    public interface ILogin
    {
        Task<string> LoginUser(Login user);

    }
}