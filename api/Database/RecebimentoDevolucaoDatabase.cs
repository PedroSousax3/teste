using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class RecebimentoDevolucaoDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
        public async Task<Models.TbRecebimentoDevolucao> InserirDatabase(Models.TbRecebimentoDevolucao novo)
        {
            await db.TbRecebimentoDevolucao.AddAsync(novo);
            await db.SaveChangesAsync();

            return novo;
        }

        public async Task<List<Models.TbRecebimentoDevolucao>> ListarRecebimentoDevolucaoDatabase(int idrecebimento)
        {
            List<Models.TbRecebimentoDevolucao> recebimentos = await db.TbRecebimentoDevolucao.Where(x => x.IdDevolucaoNavigation.IdVendaLivroNavigation.IdVendaNavigation.IdCliente == idrecebimento).ToListAsync();
        
            return recebimentos;
        }

        public async Task<Models.TbRecebimentoDevolucao> ConsultarRecebimentoDevolucaoDatabase(int idrecebimentodevolucao)
        {
            Models.TbRecebimentoDevolucao tabela = await db.TbRecebimentoDevolucao.Include(x => x.IdDevolucaoNavigation).FirstOrDefaultAsync(x => x.IdLivroDevolvido == idrecebimentodevolucao);

            return tabela;
        }

        public async Task<Models.TbRecebimentoDevolucao> AlterarRecebimentoDevolucaoDatabase(int idrecebimentodevolucao, Models.TbRecebimentoDevolucao tabela)
        {
            Models.TbRecebimentoDevolucao recebimentodevolucao = await this.ConsultarRecebimentoDevolucaoDatabase(idrecebimentodevolucao);

            recebimentodevolucao.DsStatusLivro = tabela.DsStatusLivro;
            recebimentodevolucao.DtRecebimentoLivro = tabela.DtRecebimentoLivro;
            recebimentodevolucao.IdDevolucao = tabela.IdDevolucao;
            recebimentodevolucao.IdLivroDevolvido = tabela.IdLivroDevolvido;

            await db.SaveChangesAsync();

            return recebimentodevolucao;
        }
        
        public async Task<Models.TbRecebimentoDevolucao> RemoverRecebimentoDevolucaoDatabase(int idrecebimentodevolucao)
        {
            Models.TbRecebimentoDevolucao recebimentodevolucao = await this.ConsultarRecebimentoDevolucaoDatabase(idrecebimentodevolucao);

            db.TbRecebimentoDevolucao.Remove(recebimentodevolucao);
            await db.SaveChangesAsync();

            return recebimentodevolucao;
        }
    }
}