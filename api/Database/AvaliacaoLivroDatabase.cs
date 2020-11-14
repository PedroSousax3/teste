using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class AvaliacaoLivroDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
        public async Task<Models.TbAvaliacaoLivro> InserirAvaliacaoDatabase(Models.TbAvaliacaoLivro avaliacaolivro)
        {
            await db.TbAvaliacaoLivro.AddAsync(avaliacaolivro);
            await db.SaveChangesAsync();

            return avaliacaolivro;
        }

        public async Task<Models.TbAvaliacaoLivro> ConsultarAvaliacaoPorIdDatabase(int idavaliacao)
        {
            Models.TbAvaliacaoLivro avaliacaoLivro = await db.TbAvaliacaoLivro.FirstOrDefaultAsync(x => x.IdAvaliacaoLivro == idavaliacao);

            return avaliacaoLivro;
        }

        public async Task<List<Models.TbAvaliacaoLivro>> ListarAvaliacoesDatabase(int idlivro)
        {
            List<Models.TbAvaliacaoLivro> avaliacao = await db.TbAvaliacaoLivro.Where(x => x.IdVendaLivroNavigation.IdLivro == idlivro).ToListAsync();

            return avaliacao;
        }

        public async Task<Models.TbAvaliacaoLivro> AlterarAvaliacaoDatabase(int idavaliacao, Models.TbAvaliacaoLivro novo)
        {
            Models.TbAvaliacaoLivro avaliacao = await this.ConsultarAvaliacaoPorIdDatabase(idavaliacao);
            
            novo.VlAvaliacao = avaliacao.VlAvaliacao;
            novo.DsComentario = avaliacao.DsComentario;
            novo.DtComentario = novo.DtComentario;
            
            await db.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<Models.TbAvaliacaoLivro> RemoverAvaliacaoDatabase(int idavaliacao)
        {
            Models.TbAvaliacaoLivro avaliacao = await this.ConsultarAvaliacaoPorIdDatabase(idavaliacao);

            db.TbAvaliacaoLivro.Remove(avaliacao);
            await db.SaveChangesAsync();

            return avaliacao;
        }
    }
}