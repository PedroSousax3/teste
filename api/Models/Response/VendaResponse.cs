using System;

using System.Collections.Generic;
namespace api.Models.Response
{
    public class VendaResponse
    {
        public int id { get; set; }
        public int cliente { get; set; }
        public int endereco { get; set; }
        public string metodo_pagamento { get; set; }
        public int? parcela { get; set; }
        public string status_pagamento { get; set; }
        public DateTime? data_venda { get; set; }
        public decimal? valor_frete { get; set; }
        public string codigo_rastreio { get; set; }
        public DateTime? previsao_entrega { get; set; }
        public sbyte? comfirmacao_entraga { get; set; }
        public string nota_fiscal { get; set; }

    }
    public class RelatorioQuantidadeVenda
    {
        public string DiaDaVenda { get; set; }
        public string NomeCliente { get; set; }
        public decimal? TotalCompra { get; set; }
        public string Hora { get; set; }
        public int QtdProdutosDiferentes { get; set; }
        public int QtdTotalDeProdutos { get; set; }
        public string EnderecoDeEntrega { get; set; }
        public List<Livro> Livros {get;set;}

    }
    public class Livro
    {
        public string NomeLivro { get; set; }
        public int QtdUnitaria {get;set;}
        public decimal ValorUnitario {get;set;}
    }

    public class RelatorioTop10Clientes
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int QtdCompras { get; set; }
        public decimal TotalGasto { get; set; }
    }

    public class VendasPorMesRelatorio
    {
        public string Mes { get; set; }
        public int QtdVendas { get; set; }
        public decimal? TotalVenda { get; set; }
    }

    public class Top10Vendas
    {
        public string Produto { get; set; }
        public int QuantidadeVenda { get; set; }
        public decimal TotalGasto { get; set; }
    }
}
