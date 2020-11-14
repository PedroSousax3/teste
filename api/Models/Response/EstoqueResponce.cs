using System;

namespace api.Models.Response
{
    public class EstoqueResponce
    {
        public int id { get; set; }
        public int livro { get; set; }
        public int qtd { get; set; }
        public DateTime atualizacao { get; set; }
    }
}