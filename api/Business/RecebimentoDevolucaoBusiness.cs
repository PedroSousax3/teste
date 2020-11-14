using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace api.Business
{
    public class RecebimentoDevolucaoBusiness:Validador.ValidadorRecebimentoDevolucao
    {
        Database.RecebimentoDevolucaoDatabase database = new Database.RecebimentoDevolucaoDatabase();
        public async Task<Models.TbRecebimentoDevolucao> ValidarInserirRecebimentoDevolucao(Models.TbRecebimentoDevolucao tabela)
        {
             ValidarRecebimentoDevolucao(tabela);
            return await database.InserirDatabase(tabela); 
        }
        public Task<List<Models.TbRecebimentoDevolucao>> ValidarListarRecebimentoDevolucao(int id)
        {
            ValidarId(id);
            return database.ListarRecebimentoDevolucaoDatabase(id);
        }

        public Task<Models.TbRecebimentoDevolucao> ConsultarRecebimentoDevolucaoPorId(int id)
        {
            ValidarId(id);
            return database.ConsultarRecebimentoDevolucaoDatabase(id);
        }

        public async Task<Models.TbRecebimentoDevolucao> ValidarAlterarRecebimentoDevolucao(int id,Models.TbRecebimentoDevolucao tabela)
        {
            ValidarRecebimentoDevolucao(tabela);
            return await database.AlterarRecebimentoDevolucaoDatabase(id,tabela);
        }

        public async Task<Models.TbRecebimentoDevolucao> ValidarRemoverRecebimentoDevolucao(int id)
        {
            ValidarId(id);
            return await database.RemoverRecebimentoDevolucaoDatabase(id);
        }
    }
}