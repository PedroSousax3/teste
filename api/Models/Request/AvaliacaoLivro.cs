using System;

namespace api.Models.Request
{
    public class AvaliacaoLivro
    {
        public int cliente { get; set; }
        public int venda_livro { get; set; }
        public decimal avaliacao { get; set; }
        public string comentario { get; set; }
    }
}