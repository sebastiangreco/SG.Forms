using SG.Forms.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG.Forms.Services.User
{
    public interface IUserService
    {
        Task<LoginResponse> LoginAsync(string username, string password);        
    }
}
