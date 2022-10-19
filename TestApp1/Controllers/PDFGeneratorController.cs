using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp1.Dto;
using TestApp1.Service;

namespace TestApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFGeneratorController : ControllerBase
    {
        IGeneratePdfService _pdfMethod;
        IConfiguration config;
        public PDFGeneratorController(IGeneratePdfService pdfMethod,IConfiguration _config) { 
            _pdfMethod = pdfMethod; 
            config = _config;   
        }
        /// <summary>
        /// This method is used to generate the pdf
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GeneratePDF")]
        [AuthorizationFilter]
        public async Task<JsonResult> GeneratePDF([FromBody] GeneratePdfDto input) {
            return new JsonResult(await _pdfMethod.GeneratePDF(input,config.GetSection("Setting:Domain").Value));     
        }
    }
}
