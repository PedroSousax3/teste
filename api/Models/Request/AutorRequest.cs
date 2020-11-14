using System;
using Microsoft.AspNetCore.Http;

namespace api.Models.Request
{
    public class AutorRequest
    {
        public string nome { get; set; }
        public DateTime nascimento { get; set; }
        public string descricao { get; set; }
        public IFormFile foto { get; set; }
    }
}