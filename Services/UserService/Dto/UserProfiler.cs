using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppDataAccess.DBEntity;
using AutoMapper;

namespace TestAppServices.UserService.Dto
{
    public class UserProfiler: Profile 
    {
        public UserProfiler() {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
