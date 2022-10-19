using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components.Forms;
using PuppeteerSharp;
using System.Reflection.PortableExecutable;
using TestApp1.Dto;

namespace TestApp1.Service
{
    public class GeneratePdfService: IGeneratePdfService
    {
        IWebHostEnvironment _env;
        public GeneratePdfService(IWebHostEnvironment env) { 
           _env = env;  
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">all the required parameter</param>
        /// <param name="domain">Where the application is hosted</param>
        /// <returns></returns>
        public async Task<ResponseMaker<GeneratePdfOutputDto>> GeneratePDF(GeneratePdfDto input,string domain)
        {
            ResponseMaker<GeneratePdfOutputDto> responseMaker = new ResponseMaker<GeneratePdfOutputDto>();
            if (input != null)
            {
                if (input.Html != "" && !string.IsNullOrEmpty(input.Html))
                {
                    try
                    {
                        GeneratePdfOutputDto outputDto = new GeneratePdfOutputDto();
                        using var browserFetcher = new BrowserFetcher();
                        await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
                        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                        {
                            Headless = true
                        });
                        using var page = await browser.NewPageAsync();
                        await page.SetContentAsync(input.Html);
                        string fileName = $"{Guid.NewGuid().ToString().Replace("-", "")}.pdf";
                        string path = Path.Combine(_env.ContentRootPath, "Pdf", fileName);
                        string temppath = Path.Combine(_env.ContentRootPath, "TempPdf", fileName);
                        await page.PdfAsync(temppath);
                        if (input.Passphrase != "" && !string.IsNullOrEmpty(input.Passphrase))
                        {
                            using (Stream inputfile = new FileStream(temppath, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                using (Stream output = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    PdfReader reader = new PdfReader(inputfile);
                                    PdfEncryptor.Encrypt(reader, output, true, input.Passphrase, input.Passphrase, PdfWriter.ALLOW_SCREENREADERS);
                                }
                            }
                            File.Delete(temppath);
                        }
                        else
                        {
                            File.Copy(temppath, path, true);
                            File.Delete(temppath);
                        }
                        outputDto.PdfDownloadLink = $"{domain}/resources/{fileName}";
                        responseMaker.Data = outputDto;
                        responseMaker.Success = true;
                    }
                    catch (Exception ex)
                    {
                        responseMaker.ErrorCode = 500;
                        responseMaker.ErrorDetails = ex.ToString();
                        responseMaker.Success = false;
                    }
                }
                else
                {
                    responseMaker.ErrorCode = 500;
                    responseMaker.ErrorDetails = "Please input value for Html parameter.";
                    responseMaker.Success = false;
                }
            }
            else {
                responseMaker.ErrorCode = 500;
                responseMaker.ErrorDetails = "Please input values for paramteres";
                responseMaker.Success = false;
            }
            return responseMaker;
        }
    }
}
