using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace api.Database
{
    public class MedidasDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();
        public async Task<Models.TbMedida> CadastrarMedidas(Models.TbMedida tabela)
        {
            await context.TbMedida.AddAsync(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }

        public Task<List<Models.TbMedida>> ListarMedidas()
        {
            return context.TbMedida.ToListAsync();
        }

        public Task<Models.TbMedida> ConsultarPorIdMedidas(int id)
        {
           return context.TbMedida.FirstOrDefaultAsync(x => x.IdMedida == id);
        }

        public async Task<Models.TbMedida> AlterarMedidas(int id,Models.TbMedida novaTabela)
        {
            Models.TbMedida tabela = await ConsultarPorIdMedidas(id);
            tabela.VlAltura = novaTabela.VlAltura;
            tabela.VlLargura = novaTabela.VlLargura;
            tabela.VlPeso = novaTabela.VlPeso;
            tabela.VlProfundidades = novaTabela.VlProfundidades;
            await context.SaveChangesAsync();
            return tabela;
        }
        
        public async Task<Models.TbMedida> DeletarMedidas(int id)
        {
            Models.TbMedida tabela = await ConsultarPorIdMedidas(id);
            context.TbMedida.Remove(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }
    }
}