using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace api.Database
{
    public class AutorDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();
        public async Task<Models.TbAutor> CadastrarAutor(Models.TbAutor tabela)
        {
           await context.TbAutor.AddAsync(tabela);
           await context.SaveChangesAsync();
           return tabela;
        }

        public Task<Models.TbAutor> ConsultarAutorPorId(int id)
        {
            return context.TbAutor.FirstOrDefaultAsync(x => x.IdAutor == id);
        }

        public async Task<Models.TbAutor> AlterarAutor(int id,Models.TbAutor tabela)
        {
            Models.TbAutor tabelaAutor = await ConsultarAutorPorId(id);
            tabelaAutor.DsAutor = tabela.DsAutor;
            tabelaAutor.DtNascimento = tabela.DtNascimento;
            tabelaAutor.NmAutor = tabela.NmAutor;
            await context.SaveChangesAsync();
            return tabelaAutor;
        }
        public async Task<Models.TbAutor> DeletarAutor(int id)
        {
            Models.TbAutor tabela = await ConsultarAutorPorId(id);
            context.TbAutor.Remove(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }
        public Task<List<Models.TbAutor>> ListarAutores()
        {
            return context.TbAutor.ToListAsync();
        }
    }
}