using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppServices.UserService.Dto;

namespace TestAppServices.UserService
{
    public interface IUserService
    {
        Task<UserServiceResponse<UserDto>> CreateUser(UserDto input);
        Task<UserServiceResponse<UserDto>> VerifyUser(string token);
        Task<UserServiceResponse<UserDto>> LoginUser(LoginDto input);
        bool IsApiKeyValid(string apiKey);
    }
}
