using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace api.Utils.Conversor
{
    public class VendaStatusConversor
    {
        public Models.TbVendaStatus ConversorTabela(Models.Request.VendaStatusRequest request)
        {
            Models.TbVendaStatus tabela = new Models.TbVendaStatus();
            tabela.DsVendaStatus = request.DsVendaStatus;
            tabela.DtAtualizacao = DateTime.Now;
            tabela.IdVenda = request.venda;
            tabela.NmStatus = request.status;
            return tabela;
        }

        public Models.Response.VendaStatusResponse ConversorResponse(Models.TbVendaStatus tabela)
        {
            Models.Response.VendaStatusResponse response = new Models.Response.VendaStatusResponse();
            response.id = tabela.IdVendaStatus;
            response.DsVendaStatus = tabela.DsVendaStatus;
            response.DtAtualizacao = tabela.DtAtualizacao;
            response.status = tabela.NmStatus;
            response.venda = tabela.IdVenda;
            return response;
        }
        public Models.Response.RealizarVendaResponse ParaResponseRealizarVenda(Models.TbVendaStatus tabela)
        {
            Models.Response.RealizarVendaResponse response = new Models.Response.RealizarVendaResponse();
            Utils.Conversor.VendaConversor conversorVenda = new Utils.Conversor.VendaConversor();
            Utils.Conversor.VendaStatusConversor conversorVendastatus = new Utils.Conversor.VendaStatusConversor();
            response.IdVenda = tabela.IdVenda;
            response.Venda = conversorVenda.ConversorResponse(tabela.IdVendaNavigation);
            response.Status = conversorVendastatus.ConversorResponse(tabela);
            return response;
        }
    }
}