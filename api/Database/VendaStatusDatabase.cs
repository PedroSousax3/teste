using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
namespace api.Database
{
    public class VendaStatusDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();

        public async Task<List<Models.TbVendaStatus>> ConsultarPendentes(int idCliente)
        {
           return await context.TbVendaStatus.Include(x =>x.IdVendaNavigation)
                                  .Include(x => x.IdVendaNavigation)
                                  .Where(x =>x.NmStatus == "Pendente" 
                                  && x.IdVendaNavigation.IdCliente == idCliente)
                                  .ToListAsync();
        }
        public async Task<List<Models.TbVendaStatus>> ConsultarFinalizadas(int idCliente)
        {
           return await context.TbVendaStatus.Include(x =>x.IdVendaNavigation)
                                  .Include(x => x.IdVendaNavigation.TbVendaLivro)
                                  .Where(x =>x.NmStatus == "Finalizada" 
                                  && x.IdVendaNavigation.IdCliente == idCliente)
                                  .ToListAsync();
        }
        public async Task<List<Models.TbVendaStatus>> ConsultarEmAndamento(int idCliente)
        {
           return await context.TbVendaStatus.Include(x =>x.IdVendaNavigation)
                                  .Include(x => x.IdVendaNavigation.TbVendaLivro)
                                  .Where(x =>x.NmStatus == "Em Andamento" 
                                  && x.IdVendaNavigation.IdCliente == idCliente)
                                  .ToListAsync();
        }
        public async Task<Models.TbVendaStatus> CadastrarVendaStatus(Models.TbVendaStatus tabela)
        {
            await context.TbVendaStatus.AddAsync(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }

        public Task<Models.TbVendaStatus> ConsultarPorIdVendaStatus(int id)
        {
            return context.TbVendaStatus.FirstOrDefaultAsync(x => x.IdVendaStatus == id);
        }

        public Task<Models.TbVendaStatus> ConsultarVendaStatusPorIdVenda(int id)
        {
            return context.TbVendaStatus.FirstOrDefaultAsync(x => x.IdVendaNavigation.IdVenda == id);
        }

        public async Task<Models.TbVendaStatus> AlterarVendaStatus(int id)
        {
            Models.TbVendaStatus tabela = await ConsultarPorIdVendaStatus(id);
            tabela.DsVendaStatus = "Cancelamento Solicitado";
            tabela.DtAtualizacao = DateTime.Now;
            tabela.NmStatus = "Cancelar";
            await context.SaveChangesAsync();
            return tabela;
        }

        public async Task<Models.TbVendaStatus> DeletarVendaStatus(int id)
        {
            Models.TbVendaStatus tabela = await ConsultarPorIdVendaStatus(id);
            context.TbVendaStatus.Remove(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }
    }
}