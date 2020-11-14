using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
namespace api.Utils.Conversor
{
    public class VendaConversor
    {
        public Models.TbVenda ConversorTabela(Models.Request.VendaRequest request)
        {
            Models.TbVenda tabela = new Models.TbVenda();

            tabela.IdEndereco = request.endereco;
            tabela.IdCliente = request.cliente;
            tabela.NrParcela = request.parcela;
            tabela.TpPagamento = request.metodo_pagamento;
            tabela.VlFrete = request.valor_frete;
            tabela.DsCodigoRastreio = request.codigo_rastreio;
            tabela.DsStatusPagamento = request.status_pagamento;
            tabela.DtPrevistaEntrega = request.previsao_entrega;
            tabela.BtConfirmacaoEntrega = request.comfirmacao_entraga;
            tabela.DsNf = request.nota_fiscal;
            tabela.DtVenda = request.data_venda;

            return tabela;
        }

        public Models.Response.VendaResponse ConversorResponse(Models.TbVenda tabela)
        {
            Models.Response.VendaResponse response = new Models.Response.VendaResponse();

            response.endereco = tabela.IdEndereco;
            response.cliente = tabela.IdCliente;
            response.parcela = tabela.NrParcela;
            response.metodo_pagamento = tabela.TpPagamento;
            response.valor_frete = tabela.VlFrete;
            response.codigo_rastreio = tabela.DsCodigoRastreio;
            response.status_pagamento = tabela.DsStatusPagamento;
            response.previsao_entrega = tabela.DtPrevistaEntrega;
            response.comfirmacao_entraga = tabela.BtConfirmacaoEntrega;
            response.nota_fiscal = tabela.DsNf;
            response.data_venda = tabela.DtVenda;

            return response;
        }
        public Models.Response.RelatorioQuantidadeVenda RelatorioVendaPorDiaResponse(Models.TbVenda tabela)
        {
            Models.Response.RelatorioQuantidadeVenda response = new Models.Response.RelatorioQuantidadeVenda();
            response.DiaDaVenda = tabela.DtVenda.Value.Day + "/" + tabela.DtVenda.Value.Month + "/" + tabela.DtVenda.Value.Year;
            response.EnderecoDeEntrega = tabela.IdEnderecoNavigation.NmEndereco;
            response.NomeCliente = tabela.IdClienteNavigation.NmCliente;
            decimal total = 0;
            response.Livros = new  List<Models.Response.Livro>();
            foreach (Models.TbVendaLivro livro in tabela.TbVendaLivro)
            {
                        total += (livro.VlVendaLivro * livro.NrLivros); 
                        response.QtdTotalDeProdutos += livro.NrLivros;
                 response.Livros.Add( new Models.Response.Livro()
                    {
                        NomeLivro = livro.IdLivroNavigation.NmLivro,
                        QtdUnitaria = livro.NrLivros,
                        ValorUnitario = livro.IdLivroNavigation.VlPrecoVenda
                    }
                );
            }

            response.QtdProdutosDiferentes = tabela.TbVendaLivro.Count;
            response.TotalCompra = total;
            response.Hora = tabela.DtVenda.ToString().Substring(10,9);

            return response;
        }

        public List<Models.Response.VendasPorMesRelatorio> ParaResponseRelatorioPorMes(DateTime mesInicio,DateTime mesFim,List<Models.TbVenda> tabela)
        {
            List<Models.Response.VendasPorMesRelatorio> resp = new List<Models.Response.VendasPorMesRelatorio>();
            for(int i = mesInicio.Month; i <= mesFim.Month; i++)
            {  
                Models.Response.VendasPorMesRelatorio relatorioResponse = new Models.Response.VendasPorMesRelatorio();

                List<Models.TbVenda> ConsultaMes = tabela.Where(x => x.DtVenda.Value.Month == i).ToList();

                string mes = "";
                switch (i)
                {
                    case 1: mes = "Janeiro"; break;
                    case 2: mes = "Fevereiro"; break;
                    case 3: mes = "Março"; break;
                    case 4: mes = "Abril"; break;
                    case 5: mes = "Maio"; break;
                    case 6: mes = "Junho"; break;
                    case 7: mes = "Julho"; break;
                    case 8: mes = "Agosto"; break;
                    case 9: mes = "Setembro"; break;
                    case 10: mes = "Outubro"; break;
                    case 11: mes = "Novembro"; break;
                    case 12: mes = "Dezembro"; break;
                }

                relatorioResponse.Mes = mes;
                relatorioResponse.QtdVendas = ConsultaMes.Count;
                foreach(Models.TbVenda item in ConsultaMes)
                {

                    relatorioResponse.TotalVenda = item.TbVendaLivro.Sum(x => x.VlVendaLivro);
                }

                resp.Add(relatorioResponse);  
            }
            return resp;
        }

        public List<Models.Response.RelatorioTop10Clientes> ParaResponseTopClientes(List<Models.TbVenda> tabela)
        {
 
            List<Models.Response.RelatorioTop10Clientes> relatorioTopClientes = new List<Models.Response.RelatorioTop10Clientes>();

            foreach(Models.TbVenda item in tabela)
            {
                Models.Response.RelatorioTop10Clientes topClientes = new Models.Response.RelatorioTop10Clientes();

                topClientes.Email = item.IdClienteNavigation.DsEmail;
                topClientes.Nome = item.IdClienteNavigation.NmCliente;
                if(item.IdClienteNavigation.TbVenda.Count == 0) continue;
                topClientes.QtdCompras = item.IdClienteNavigation.TbVenda.Count;
                topClientes.Telefone = item.IdEnderecoNavigation.DsCelular;
                topClientes.TotalGasto = item.TbVendaLivro.Sum(x => x.VlVendaLivro);
                List<bool> help = new List<bool>();
                foreach (Models.Response.RelatorioTop10Clientes adicionar in relatorioTopClientes)
                {
                    if(adicionar.Email != item.IdClienteNavigation.DsEmail)
                    {
                        help.Add(true);
                    } 
                    else
                    {
                       adicionar.TotalGasto += topClientes.TotalGasto ;
                        help.Add(false);
                    };
                }
                if(help.All(x => x == true)) relatorioTopClientes.Add(topClientes);

                }

            relatorioTopClientes = relatorioTopClientes.OrderByDescending(x => x.TotalGasto).ToList();
            return relatorioTopClientes.Take(10).ToList();
        }
    }
}