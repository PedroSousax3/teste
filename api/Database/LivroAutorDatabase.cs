using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace api.Database
{
    public class LivroAutorDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();

        public async Task<Models.TbLivroAutor> CadastrarLivroAutor(Models.TbLivroAutor tabela)
        {
            await context.AddAsync(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }

        public Task<List<Models.TbLivroAutor>> ListarLivroAutorPorIdLivro(int id)
        {
            return context.TbLivroAutor.Include(x => x.IdAutorNavigation).Include(x =>x.IdLivroNavigation)
                                           .Where(x => x.IdLivroNavigation.IdLivro == id).ToListAsync();
        }
        public async Task<List<Models.TbLivroAutor>> ListarLivroAutorPorIdAutor(int id)
        {
           return await context.TbLivroAutor.Include(x => x.IdLivroNavigation).Include(x => x.IdAutorNavigation)
                                            .Where(x => x.IdAutorNavigation.IdAutor == id).ToListAsync();
        }
        public Task<List<Models.TbLivroAutor>> ListarLivroAutor()
        {
            return context.TbLivroAutor.Include(x => x.IdAutorNavigation).Include(x => x.IdLivroNavigation).ToListAsync();
        }

        public Task<Models.TbLivroAutor> ConsultarPorIdLivroAutor(int id)
        {
            return context.TbLivroAutor.FirstOrDefaultAsync(x => x.IdLivroAutor == id);
        }

        public async Task<Models.TbLivroAutor> DeletarLivroAutor(int id)
        {
            Models.TbLivroAutor tabela = await ConsultarPorIdLivroAutor(id);
            context.TbLivroAutor.Remove(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }
        public async Task<Models.TbLivroAutor> AlterarLivroAutor(int id,Models.TbLivroAutor novaTabela)
        {
            Models.TbLivroAutor tabela = await ConsultarPorIdLivroAutor(id);
            tabela.IdAutor = novaTabela.IdAutor;
            tabela.IdLivro = novaTabela.IdLivro;
            return tabela;
        }
    }
}