using System;

using System.Linq;
using System.Collections.Generic;

namespace api.Utils.Conversor
{
    public class CarrinhoConversor
    {
        public Models.TbCarrinho ConversorTabela (Models.Request.CarrinhoRequest request)
        {
            Models.TbCarrinho tabela = new Models.TbCarrinho();
            
            tabela.IdCliente = request.cliente;
            tabela.IdLivro = request.livro;
            tabela.NrLivro = request.qtd;
            tabela.DtAtualizacao = DateTime.Now;

            return tabela;
        }

        public Models.Response.CarrinhoResponse ConversorResponseLite (Models.TbCarrinho tabela)
        {
            Models.Response.CarrinhoResponse response = new Models.Response.CarrinhoResponse();            

            response.id = tabela.IdCarrinho;
            response.cliente = tabela.IdCliente;
            response.qtd = tabela.NrLivro;
            response.atualizacao = tabela.DtAtualizacao;

            return response;
        }

        public Models.Response.CarrinhoResponse ConversorResponse (Models.TbCarrinho tabela)
        {
            Models.Response.CarrinhoResponse response = new Models.Response.CarrinhoResponse();            

            response.id = tabela.IdCarrinho;
            response.cliente = tabela.IdCliente;
            response.qtd = tabela.NrLivro;
            response.atualizacao = tabela.DtAtualizacao;
            
            LivroConversor LivroConvert = new LivroConversor();
            AutorConversor AutorConvert = new AutorConversor();
            EstoqueConvert EstoqueConvert = new EstoqueConvert();
            EditoraConversor EditoraConvert = new EditoraConversor();
            
            if(tabela.IdLivroNavigation == null)
                response.informacoes = null;
            else 
                response.informacoes = LivroConvert.Conversor(tabela.IdLivroNavigation);
            if(tabela.IdLivroNavigation.TbLivroAutor == null)
                response.autores = null;
            else
                response.autores = tabela.IdLivroNavigation.TbLivroAutor.Select(x => AutorConvert.ConversorResponse(x.IdAutorNavigation)).ToList();
            if(tabela.IdLivroNavigation.TbEstoque == null)
                response.estoque = null;
            else
                response.estoque = EstoqueConvert.ConversorResponse(tabela.IdLivroNavigation.TbEstoque.FirstOrDefault(x => x.IdLivro == response.informacoes.id));
            if(tabela.IdLivroNavigation.IdEditoraNavigation == null)
                response.informacoes.editora = null;
            else
                response.informacoes.editora = EditoraConvert.Conversor(tabela.IdLivroNavigation.IdEditoraNavigation);
            
            return response;
        }
    }
}