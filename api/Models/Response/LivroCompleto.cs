using api.Models.Response;
using System.Collections.Generic;

namespace api.Models.Response
{
    public class LivroCompleto
    {
        public int idlivro { get; set; }
        public LivroResponse livro { get; set; }
        public List<AutorResponse> autores { get; set; }
        public List<GeneroResponse> generos { get; set; }
        public EstoqueResponce estoque_livro { get; set; }
    }
}