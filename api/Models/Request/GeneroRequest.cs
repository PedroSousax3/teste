using Microsoft.AspNetCore.Http;
namespace api.Models.Request
{
    public class GeneroRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IFormFile Foto { get; set; }
    }
}