using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestAppDataAccess.DBEntity;
using TestAppDataAccess.Repository;
using TestAppServices.UserService.Dto;

namespace TestAppServices.UserService
{
    
    public class UserService:IUserService
    {
        IRepository<UserEntity> repository;
        IMapper mapper;
        public UserService(IRepository<UserEntity> _repository, IMapper _mapper) { 
            repository = _repository;
            mapper = _mapper;
        }
        public async Task<UserServiceResponse<UserDto>> CreateUser(UserDto input) {
                UserServiceResponse<UserDto> output = new UserServiceResponse<UserDto>();
                //Check if user already exist     
                var dbUsers = repository.GetAll(x => x.UserName == input.UserName);
                if (dbUsers.Count() > 0)
                {
                    output.Success = false;
                    output.Error = Constant.USER_EXIST;
                }
                else
                {
                    //Create new user
                    UserEntity user = mapper.Map<UserEntity>(input);
                    user.ApiKey = Guid.NewGuid().ToString().Replace("-", "");
                    user.VerificationToken = Guid.NewGuid().ToString().Replace("-", "");
                    user.CreatedOn = DateTime.UtcNow;
                    user.IsVerified = false;
                    input = mapper.Map<UserDto>(user);
                    output.Data = input; 
                    await repository.AddAsync(user);
                    output.Success = true;
                }

           
            return output;
        }
        public async Task<UserServiceResponse<UserDto>> VerifyUser(string token)
        {
            UserServiceResponse<UserDto> output = new UserServiceResponse<UserDto>();
            var dbUsers = repository.GetAll(x => x.VerificationToken == token);
            if (dbUsers.Count() > 0)
            {
                var user = dbUsers.FirstOrDefault();
                if ((DateTime.UtcNow - Convert.ToDateTime(user.CreatedOn)).Days < 1)
                {
                    user.IsVerified = true;
                    user.VerificationToken = string.Empty;
                    user.VerifiedOn = DateTime.UtcNow;
                    await repository.UpdateAsync(user);
                    output.Success = true;
                }
                else {
                    output.Success = false;
                    output.Error = Constant.LINK_EXPIRE;
                }
            }
            else
            {
                output.Success = false;
                output.Error = Constant.USER_NOT_EXIST;
            }
            return output;
        }
        public bool IsApiKeyValid(string apiKey)
        {
            var dbUsers = repository.GetAll(x => x.ApiKey == apiKey && (x.IsVerified??false));
            if (dbUsers.Count() > 0)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
        public async Task<UserServiceResponse<UserDto>> LoginUser(LoginDto input)
        {
            UserServiceResponse<UserDto> output = new UserServiceResponse<UserDto>();
            var dbUsers = repository.GetAll(x => x.UserName == input.UserName);
            if (dbUsers.Count() > 0)
            {
                var user = dbUsers.FirstOrDefault();
                if (user.Password == input.Password && (user.IsVerified ?? false))
                {
                    output.Success = true;
                    output.Data = mapper.Map<UserDto>(user);
                }
                else
                {
                    if (user.IsVerified ?? false)
                    {
                        output.Error = Constant.USER_INVALID_PASSWORD;
                    }
                    else {
                        output.Error = Constant.USER_IS_NOT_VERIFIED;
                    }
                    output.Success = false;
                  
                }
            }
            else
            {
                output.Success = false;
                output.Error = Constant.USER_NOT_EXIST;
            }
            return output;
        }
    }
}
