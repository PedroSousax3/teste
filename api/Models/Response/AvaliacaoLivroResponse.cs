using System;

namespace api.Models.Response
{
    public class AvaliacaoLivroResponse
    {
        public int id { get; set; }
        public int cliente { get; set; }
        public int venda_livro { get; set; }
        public decimal avaliacao { get; set; }
        public string comentario { get; set; }
        public DateTime data_publicacao { get; set; }
    }
}