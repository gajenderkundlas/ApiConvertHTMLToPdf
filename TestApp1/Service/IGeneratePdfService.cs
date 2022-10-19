using TestApp1.Dto;

namespace TestApp1.Service
{
    public interface IGeneratePdfService
    {
        Task<ResponseMaker<GeneratePdfOutputDto>> GeneratePDF(GeneratePdfDto input, string domain);
    }
}
