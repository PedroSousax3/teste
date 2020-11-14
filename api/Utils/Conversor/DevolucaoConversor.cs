using System;
namespace api.Utils.Conversor
{
    public class DevolucaoConversor
    {
        public Models.TbDevolucao ConversorTabela(Models.Request.DevolucaoRequest request)
        {
            Models.TbDevolucao tabela = new Models.TbDevolucao();

            tabela.IdVendaLivro = request.vendalivro;
            tabela.DsCodigoRastreio = "....";
            tabela.DsMotivo = request.motivo;
            tabela.DtDevolucao = DateTime.Now;
            tabela.DtPrevisaoEntrega = request.previsao_entrega;
            tabela.BtDevolvido = 1;
            tabela.VlDevolvido = request.valor;

            return tabela;
        }

        public Models.Response.DevolucaoResponse ConversorResponse(Models.TbDevolucao tabela)
        {
            Models.Response.DevolucaoResponse response = new Models.Response.DevolucaoResponse();

            response.id = tabela.IdDevolucao;
            response.vendalivro = tabela.IdVendaLivro ;
            response.codigo_ratreio = tabela.DsCodigoRastreio;
            response.motivo = tabela.DsMotivo;
            response.data_devolucao = tabela.DtDevolucao;
            response.previsao_entrega = tabela.DtPrevisaoEntrega;
            response.devolvido = tabela.BtDevolvido ;
            response.valor = tabela.VlDevolvido;

            return response;
        }
    }
}