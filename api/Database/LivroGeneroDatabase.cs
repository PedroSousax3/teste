using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace api.Database
{
    public class LivroGeneroDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();

        public async Task<Models.TbLivroGenero> CadastrarLivroGenero(Models.TbLivroGenero tabela)
        {
           await context.TbLivroGenero.AddAsync(tabela);
           await context.SaveChangesAsync();
           return tabela;
        }

        public Task<List<Models.TbLivroGenero>> ListarLivroGeneroPorIdLivro(int id)
        {
            return context.TbLivroGenero.Include(x => x.IdGeneroNavigation).Include(x => x.IdLivroNavigation)
                                        .Where(x => x.IdLivroNavigation.IdLivro == id).ToListAsync();
        }

        public Task<List<Models.TbLivroGenero>> ListarLivroGeneroPorIdGenero(int id)
        {
            return context.TbLivroGenero.Include(x => x.IdGeneroNavigation).Include(x => x.IdLivroNavigation)
                                        .Where(x => x.IdGeneroNavigation.IdGenero == id).ToListAsync();
        }

        public Task<Models.TbLivroGenero> ConsultarPorIdLivroGenero(int id)
        {
            return context.TbLivroGenero.Include(x => x.IdLivroGenero).Include(x =>x.IdLivroNavigation)
                                        .FirstOrDefaultAsync(x => x.IdLivroGenero == id);
        }

        public async Task<Models.TbLivroGenero> DeletarLivroGenero(int id)
        {
            Models.TbLivroGenero tabela = await ConsultarPorIdLivroGenero(id);
            context.TbLivroGenero.Remove(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }

        public async Task<Models.TbLivroGenero> AlterarLivroGenero(int id, Models.TbLivroGenero novaTabela)
        {
            Models.TbLivroGenero tabela = await ConsultarPorIdLivroGenero(id);
            tabela.IdGenero = novaTabela.IdGenero;
            tabela.IdLivro = novaTabela.IdLivro;
            await context.SaveChangesAsync();
            return tabela;
        }
    }
}