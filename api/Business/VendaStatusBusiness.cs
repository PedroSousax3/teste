using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace api.Business
{
    public class VendaStatusBusiness:Validador.ValidadorVendaStatus
    {
       Database.VendaStatusDatabase database = new Database.VendaStatusDatabase();
       
       public async Task<List<Models.TbVendaStatus>> ListarPendentes(int idCliente)
       {
           return await database.ConsultarPendentes(idCliente);
       }

           public async Task<List<Models.TbVendaStatus>> ListarFinalizadas(int idCliente)
       {
           return await database.ConsultarFinalizadas(idCliente);
       }

           public async Task<List<Models.TbVendaStatus>> ListarEmAndamento(int idCliente)
       {
           return await database.ConsultarEmAndamento(idCliente);
       }
       public async Task<Models.TbVendaStatus> ValidarCadastrarVendaStatus(Models.TbVendaStatus tabela)
       {
          ValidarVendaStatus(tabela);
          return await database.CadastrarVendaStatus(tabela);
       }

       public Task<Models.TbVendaStatus> ValidarVendaStatusConsultarPorId(int id)
       {
          ValidarId(id);
          return database.ConsultarPorIdVendaStatus(id);
       } 

       public Task<Models.TbVendaStatus> ValidarVendaStatusConsultarPorIdvenda(int id)
         {
            ValidarId(id);
            return database.ConsultarVendaStatusPorIdVenda(id);
         } 

         public async Task<Models.TbVendaStatus> ValidarAlterarVendaStatus(int id)
         {
            ValidarId(id);
            return await database.AlterarVendaStatus(id);
         }

         public async Task<Models.TbVendaStatus> ValidarDeletarVendaStatus(int id)
         {
            ValidarId(id);
            return await database.DeletarVendaStatus(id);
         }
    }
}