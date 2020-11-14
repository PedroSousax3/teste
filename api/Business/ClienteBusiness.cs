using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace api.Business
{
    public class ClienteBusiness : Validador.ValidadorCliente
    {
        Database.ClienteDatabase database = new Database.ClienteDatabase(); 
        public async Task<Models.TbCliente> CadastrarCliente(Models.TbCliente tabela)
        {
            ValidarCliente(tabela);
            return await database.CadastrarCliente(tabela);
        }

        public async Task<Models.TbCliente> AlterarCliente(int idCliente,Models.TbCliente tabela)
        {
            ValidarClienteAlterar(tabela);
            return await database.AlterarCliente(idCliente,tabela);
        }
        public async Task<Models.TbCliente> ValidarDeletarCliente(int id)
        {
            ValidarClienteExiste(id);
            return await database.DeletarCliente(id);
        }
        public async Task<Models.TbCliente> ValidarConsultaPorId(int id)
        {
            ValidarClienteExiste(id);
            return await database.ConsultarClientePorId(id);
        }
        public async Task<List<Models.TbCliente>> ValidarListarClientes()
        {
            return await database.ListarClientes();
        }
    }
}