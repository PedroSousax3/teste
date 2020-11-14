using System;
using System.Collections.Generic;

namespace api.Models.Request
{
    public class LivrosFiltrosRequest
    {
        public string nome { get; set; } //Nome deve ser usado para campos de pesquisa(livro, autor, edira....)
        public List<int> idgenero { get; set; }
        public DateTime data_publicacao { get; set; }
        public int edicao { get; set; }
        public string acabamento { get; set; }
        public int paginas { get; set; }
        public double valor_minimo { get; set; }
        public double valor_maximo { get; set; }
    }
}