using System;
using Microsoft.AspNetCore.Http;

namespace api.Models.Request
{
    public class LivroRequest
    {
        public int editora { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime lancamento { get; set; }
        public string idioma { get; set; }
        public string encapamento { get; set; }
        public IFormFile foto { get; set; }
        public int? paginas { get; set; }
        public string isbn { get; set; }
        public int edicao { get; set; }
        public double compra { get; set; }
        public double venda { get; set; }
        public Models.Request.MedidaRequest medidas { get; set; }
    }
}