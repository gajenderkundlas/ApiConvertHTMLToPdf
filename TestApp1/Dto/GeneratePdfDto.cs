using System.ComponentModel.DataAnnotations;


namespace TestApp1.Dto
{
    public class GeneratePdfDto
    {
        public string Html { get; set; }
        public string Passphrase { get; set; }
    }
}
