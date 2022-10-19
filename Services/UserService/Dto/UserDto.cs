using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppDataAccess.DBEntity;

namespace TestAppServices.UserService.Dto
{
    [AutoMap(typeof(UserEntity))]
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")] 
        public string Password { get; set; }
        public string? VerificationToken { get; set; }

        public string? ApiKey { get; set; }
    }

}
