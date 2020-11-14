using System.Threading.Tasks;
using System.Collections.Generic;
namespace api.Business
{
    public class AutorBusiness
    {
        Database.AutorDatabase database = new Database.AutorDatabase();
        Validador.ValidadorAutor validador = new Validador.ValidadorAutor();
        public async Task<Models.TbAutor> ValidarCadastro(Models.TbAutor tabela)
        {
            validador.ValidarAutor(tabela,"cadastrar",0);
            return await database.CadastrarAutor(tabela);
        } 
        public async Task<Models.TbAutor> ValidarConsultaPorId(int id)
        {
            validador.ValidarAutorId(id);
            return await database.ConsultarAutorPorId(id);
        }

        public async Task<Models.TbAutor> ValidarAlterar(int id,Models.TbAutor tabela)
        {
             validador.ValidarAutor(tabela,"alterar",id);
             return await database.AlterarAutor(id,tabela);
        }

        public async Task<Models.TbAutor> ValidarDeletarAutor(int id)
        {
            validador.ValidarAutorId(id);
            return await database.DeletarAutor(id); 
        }

        public Task<List<Models.TbAutor>> ValidarListarAutores()
        {
           return database.ListarAutores();
        }
    }
}