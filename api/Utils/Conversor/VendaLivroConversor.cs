using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
namespace api.Utils.Conversor
{
    public class VendaLivroConversor
    {
        Models.db_next_gen_booksContext ctx = new Models.db_next_gen_booksContext();
        public Models.TbVendaLivro ConversorTabela(Models.Request.VendaLivroRequest request)
        {
            Models.TbVendaLivro tabela = new Models.TbVendaLivro();

            tabela.IdVenda = request.venda;
            tabela.IdLivro = request.livro;
            tabela.NrLivros = request.qtd;
            tabela.VlVendaLivro = request.valor;

            return tabela;
        }

        public Models.Response.VendaLivroResponse ConversorResponse(Models.TbVendaLivro tabela)
        {
            Models.Response.VendaLivroResponse response = new Models.Response.VendaLivroResponse();
             Utils.Conversor.LivroConversor conversorLivro = new Utils.Conversor.LivroConversor();

            response.id = tabela.IdVendaLivro;
            response.venda = tabela.IdVenda;
            response.livro = tabela.IdLivro;
            response.qtd = tabela.NrLivros;
            response.valor = tabela.VlVendaLivro;
            response.devolvido = tabela.BtDevolvido;
            response.livroInfo = conversorLivro.Conversor(tabela.IdLivroNavigation);

            return response;
        }

         public List<Models.Response.Top10Vendas> ParaResponseTop10Vendas(List<Models.TbVendaLivro> tabela)
        {
            List<Models.Response.Top10Vendas> resp = new List<Models.Response.Top10Vendas>();
            foreach(Models.TbVendaLivro item in tabela)
            {
                 List<Models.TbVendaLivro> produto = ctx.TbVendaLivro.Where(x => x.IdLivroNavigation.NmLivro == item.IdLivroNavigation.NmLivro).ToList();
                Models.Response.Top10Vendas top10Vendas = new Models.Response.Top10Vendas();
                top10Vendas.Produto = item.IdLivroNavigation.NmLivro;
                foreach(Models.TbVendaLivro livro in produto)
                {
                    top10Vendas.QuantidadeVenda += livro.NrLivros;

                }
                top10Vendas.TotalGasto = produto.Sum(x => x.VlVendaLivro);
                List<bool> help = new List<bool>();
                foreach (Models.Response.Top10Vendas adicionar in resp)
                {
                    if(adicionar.Produto.ToLower() != item.IdLivroNavigation.NmLivro.ToLower())
                    {
                        help.Add(true);
                    } 
                    else
                    {
                        help.Add(false);
                    };
                }
                Console.WriteLine(help);
                if(help.All(x => x == true)) resp.Add(top10Vendas);

                }
            resp = resp.OrderByDescending(x => x.QuantidadeVenda).ToList();

            return resp.Take(10).ToList();
        }
    }
}