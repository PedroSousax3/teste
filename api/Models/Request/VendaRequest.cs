using System;

namespace api.Models.Request
{
    public class VendaRequest
    {
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
    public class RelatorioPorDiaRequest
    {
        public DateTime Dia { get; set; }
    }

    public class RelatorioVendasPorMes
    {
        public DateTime MesInicio { get; set; }
        public DateTime MesFim { get; set; }
    }
}