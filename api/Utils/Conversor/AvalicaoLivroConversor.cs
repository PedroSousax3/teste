using System;
namespace api.Utils.Conversor
{
    public class AvalicaoLivroConversor
    {
        public Models.TbAvaliacaoLivro ConversorTabela(Models.Request.AvaliacaoLivro request)
        {
            Models.TbAvaliacaoLivro tabela = new Models.TbAvaliacaoLivro();

            tabela.VlAvaliacao = request.avaliacao;
            tabela.IdVendaLivro = request.venda_livro;
            tabela.DsComentario = request.comentario;
            tabela.DtComentario = DateTime.Now;

            return tabela;
        }

        public Models.Response.AvaliacaoLivroResponse ConversorResponse(Models.TbAvaliacaoLivro tabela)
        {
            Models.Response.AvaliacaoLivroResponse response = new Models.Response.AvaliacaoLivroResponse();

            response.avaliacao = tabela.VlAvaliacao;
            response.venda_livro = tabela.IdVendaLivro;
            response.comentario = tabela.DsComentario;
            response.data_publicacao = tabela.DtComentario;

            return response;
        }
    }
}