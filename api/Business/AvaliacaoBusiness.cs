using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace api.Business
{
    public class AvaliacaoBusiness : Business.Validador.ValidadorPadrao
    {
        Database.AvaliacaoLivroDatabase database = new Database.AvaliacaoLivroDatabase();

        public async Task<Models.TbAvaliacaoLivro> InserirBusiness(Models.TbAvaliacaoLivro novo)
        {
            ValidarId(novo.IdVendaLivro);
            if(novo.VlAvaliacao < 0 || novo.VlAvaliacao > 5)
                throw new ArgumentException("Valor da avaliação é invalido, valor deve ser maior que 0 e menor ou igual 5");
            
            Models.TbAvaliacaoLivro result = await database.InserirAvaliacaoDatabase(novo);

            if(result.IdAvaliacaoLivro <= 0)
                throw new ArgumentException("Não possivel inserir a avaliação.");
            
            return result;
        }

        public async Task<Models.TbAvaliacaoLivro> ConsultarAvaliacaoIdDatabase(int id)
        {
            ValidarId(id);

            Models.TbAvaliacaoLivro avaliacao = await database.ConsultarAvaliacaoPorIdDatabase(id);
            if(avaliacao == null)
                throw new ArgumentException("Avaliação não foi encontrada.");
            
            return avaliacao;
        }

        public async Task<Models.TbAvaliacaoLivro> AlterarAvaliacaoBusiness(int idavaliacao, Models.TbAvaliacaoLivro novo)
        {

            ValidarId(novo.IdVendaLivro);
            ValidarTexto(novo.DsComentario, "Comentario não foi informado.");
            novo.DtComentario = DateTime.Now;

            Models.TbAvaliacaoLivro avaliacao = await database.AlterarAvaliacaoDatabase(idavaliacao, novo);
            if(avaliacao == null)
                throw new ArgumentException("Não foi possivel alterar esse comentario, confirme os dados e tente novamente");

            return avaliacao;
        }

        public async Task<Models.TbAvaliacaoLivro> RemoverAvaliacaoBusiness(int idavaliacao)
        {
            ValidarId(idavaliacao);
            Models.TbAvaliacaoLivro avaliacao = await database.RemoverAvaliacaoDatabase(idavaliacao);

            if(avaliacao == null)
                throw new ArgumentException("Não foi possivel alterar esse comentario, confirme os dados e tente novamente");

            return avaliacao;
        }

        public async Task<List<Models.TbAvaliacaoLivro>> ListarAvaliacoesBusiness(int idlivro)
        {
            ValidarId(idlivro);
            List<Models.TbAvaliacaoLivro> avaliacao = await database.ListarAvaliacoesDatabase(idlivro);

            if(avaliacao == null)
                throw new ArgumentException("Não foi possivel encontra os comentarios deste livro.");
            return avaliacao;
        }
    }
}