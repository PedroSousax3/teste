using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
namespace api.Database
{
    public class GeneroDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();

        public async Task<Models.TbGenero> CadastrarGenero(Models.TbGenero tabela)
        {
            await context.TbGenero.AddAsync(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }
        public async Task<Models.TbGenero> AlterarGenero(int id,Models.TbGenero novaTabela)
        {
            Models.TbGenero tabela = await ConsultarGeneroPorId(id);
            tabela.DsFoto = novaTabela.DsFoto;
            tabela.NmGenero = novaTabela.NmGenero;
            tabela.TbLivroGenero = novaTabela.TbLivroGenero;
            tabela.DsGenero = novaTabela.DsGenero;
            await context.SaveChangesAsync();

             return tabela;
        }

        public Task<List<Models.TbGenero>> ListarGeneros()
        {
           return context.TbGenero.ToListAsync();
        }

        public Task<Models.TbGenero> ConsultarGeneroPorId(int id)
        {
            return context.TbGenero.FirstOrDefaultAsync(x => x.IdGenero == id);
        }
        public async Task<Models.TbGenero> DeletarGenero(int id)
        {
           Models.TbGenero tabela = await ConsultarGeneroPorId(id);
           context.TbGenero.Remove(tabela);
           await context.SaveChangesAsync();
           return tabela;
        }
        public async Task<bool> VerificarGeneroJaExiste(string genero)
        {
            bool resposta = false;
            Models.TbGenero tabela = await context.TbGenero.FirstOrDefaultAsync(x => x.NmGenero == genero);
            if(tabela != null)
               resposta = true;
            
            return resposta;
        }

    }
}