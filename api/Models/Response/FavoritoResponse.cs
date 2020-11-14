using System;
using System.Collections.Generic;

namespace api.Models.Response
{
    public class FavoritoResponse
    {
        public int id { get; set; }
        public int livro { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime lancamento { get; set; }
        public string editora { get; set; }
        public List<string> atores { get; set; }
        public int qtd { get; set; }
    }
}