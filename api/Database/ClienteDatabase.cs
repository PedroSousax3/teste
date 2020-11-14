using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
namespace api.Database
{
    public class ClienteDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();
        public async  Task<Models.TbCliente> CadastrarCliente(Models.TbCliente tabela)
        {
            await context.AddAsync(tabela);
            await context.SaveChangesAsync();
            return tabela;  
        }
         
        public async Task<Models.TbCliente> AlterarCliente(int idCliente,Models.TbCliente nova)
        {
            Models.TbCliente tabela = await ConsultarClientePorId(idCliente);
            tabela.NmCliente = nova.NmCliente;
            tabela.DsCelular = nova.DsCelular;
            tabela.DsFoto = nova.DsFoto;
            tabela.TpGenero = nova.TpGenero;
            
            await context.SaveChangesAsync();

            return tabela;
        }
        public async Task<Models.TbCliente> DeletarCliente(int id)
        {
            Models.TbCliente tabela = await ConsultarClientePorId(id);
            context.TbCliente.Remove(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }


        public Task<List<Models.TbCliente>> ListarClientes()
        {
            return context.TbCliente.ToListAsync();
        }

        
        public Task<Models.TbCliente> ConsultarClientePorId(int id)
        {
            return context.TbCliente.FirstOrDefaultAsync(x => x.IdCliente == id);
        }
    }
}