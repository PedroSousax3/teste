using System;
using Microsoft.AspNetCore.Http;

namespace api.Models.Request
{
    public class DevolucaoRequest
    {
        public int vendalivro { get; set; }
        public string motivo { get; set; }
        public decimal valor { get; set; }
        public string codigo_ratreio { get; set; }
        public IFormFile comprovante { get; set; }
        public DateTime? previsao_entrega { get; set; }
    }
}