using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace api.Business
{
    public class LivroAutorBusiness:Validador.ValidadorPadrao
    {
         Database.LivroAutorDatabase database = new Database.LivroAutorDatabase();

        public async Task<Models.TbLivroAutor> ValidarCadastroLivroAutor(Models.TbLivroAutor tabela)
        {
            ValidarId(tabela.IdLivro);
            ValidarId(tabela.IdAutor);
            return await database.CadastrarLivroAutor(tabela);
        }

        public Task<List<Models.TbLivroAutor>> ValidarListarListarLivroAutorPorIdAutor(int id)
        {
            ValidarId(id);
            return database.ListarLivroAutorPorIdAutor(id);
        }

        public Task<List<Models.TbLivroAutor>> ValidarListarListarLivroAutorPorIdLivro(int id)
        {
            ValidarId(id);
            return database.ListarLivroAutorPorIdLivro(id);
        }

        public Task<List<Models.TbLivroAutor>> ValidarListarLivroAutor()
        {
            return database.ListarLivroAutor();
        }

        public Task<Models.TbLivroAutor> ValidarConsultarLivroAutorPorId(int id)
        {
            ValidarId(id);
            return database.ConsultarPorIdLivroAutor(id);
        }

        public async Task<Models.TbLivroAutor> ValidarDeletarLivroAutor(int id)
        {
            ValidarId(id);
            return await database.DeletarLivroAutor(id);
        }

        public async Task<Models.TbLivroAutor> ValidarAlterarLivroAutor(int id,Models.TbLivroAutor tabela)
        {
            ValidarId(tabela.IdLivro);
            ValidarId(tabela.IdAutor);
            return await database.AlterarLivroAutor(id,tabela);
        }

    }
}