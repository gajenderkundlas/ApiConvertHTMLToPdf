using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PuppeteerSharp.Input;
using System.Runtime;
using TestApp1.Dto;
using TestAppServices.UserService;

namespace TestApp1.Controllers
{
    public class AuthorizationFilter : Attribute,IAuthorizationFilter
    {
        /// <summary>
        /// Authorization filter for validate each request
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Microsoft.Extensions.Primitives.StringValues key = "";
            context.HttpContext.Request.Headers.TryGetValue("x-api-key", out key);
            IServiceProvider services = context.HttpContext.RequestServices;
            IUserService userService = services.GetService<IUserService>();
            if (!userService.IsApiKeyValid(key))
            {
                ResponseMaker<Object> response = new ResponseMaker<object>();
                response.Success = false;
                response.ErrorCode = 403;
                response.ErrorDetails = "Your api key is not valid.";
                context.Result = new UnauthorizedObjectResult(response);
                return;
            }
        }
    }
}
