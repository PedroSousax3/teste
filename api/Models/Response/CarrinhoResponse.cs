using System;
using System.Collections.Generic;

namespace api.Models.Response
{
    public class CarrinhoResponse
    {
        public int id { get; set; }
        public int cliente { get; set; }
        public DateTime atualizacao { get; set; }
        public int qtd { get; set; }
        public Models.Response.LivroResponse informacoes { get; set; }
        public List<Models.Response.AutorResponse> autores { get; set; }
        public Models.Response.EstoqueResponce estoque { get; set; }
    }
}