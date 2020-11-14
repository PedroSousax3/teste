using System.Collections.Generic;
using System;
namespace api.Models.Request
{
    public class RealizarVendaRequest
    {
        public class RealizarVendaPersonalizado
        {
            public int IdCliente { get; set; }
            public int IdEndereco { get; set; }
            public string TipoDePagamento { get; set; }
            public int NumeroParcela { get; set; }
            public decimal ValorFrete { get; set; }
            public DateTime DataPrevistaEntrega {get; set;}
            public List<Livro> Livros {get;set;}
        }
        public class Livro
        {
            public int IdLivro { get; set; }
            public int NumeroLivro { get; set; }
            public decimal VendaLivro { get; set; }
        }
    }
}