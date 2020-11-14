using System;
using System.Collections.Generic;

namespace api.Models.Response
{
    public class LivroResponse
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime lancamento { get; set; }
        public string idioma { get; set; }
        public string encapamento { get; set; }
        public string foto { get; set; }
        public int? paginas { get; set; }
        public string isbn { get; set; }
        public int edicao { get; set; }
        public double compra { get; set; }
        public double venda { get; set; }
        public Models.Response.EditoraResponse editora { get; set; }
        public Models.Response.MedidaResponse medida { get; set; }
        public bool favorito { get; set; }
    }
}