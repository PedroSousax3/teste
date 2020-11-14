using System;
using Microsoft.AspNetCore.Http;

namespace api.Models.Request
{
    public class EditoraRequest
    {
        public string nome { get; set; }
        public DateTime fundacao { get; set; }
        public IFormFile logo { get; set; }
        public string sigla { get; set; }
    }
}