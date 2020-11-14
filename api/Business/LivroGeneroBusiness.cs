using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace api.Business
{
    public class LivroGeneroBusiness:Validador.ValidadorPadrao
    {
        Database.LivroGeneroDatabase database = new Database.LivroGeneroDatabase();
        public async Task<Models.TbLivroGenero> ValidarCadastrarLivroGenero(Models.TbLivroGenero tabela)
        {
           ValidarId(tabela.IdLivro);
           ValidarId(tabela.IdGenero);
           return await database.CadastrarLivroGenero(tabela);
        }

        public Task<List<Models.TbLivroGenero>> ValidarListarGeneroPorIdLivro(int id)
        {
            ValidarId(id);
            return database.ListarLivroGeneroPorIdLivro(id);
        }

        
        public Task<List<Models.TbLivroGenero>> ValidarListarGeneroPorIdGenero(int id)
        {
            ValidarId(id);
            return database.ListarLivroGeneroPorIdGenero(id);
        }

        public Task<Models.TbLivroGenero> ValidarConsultaPorIdLivroAutor(int id)
        {
            ValidarId(id);
            return database.ConsultarPorIdLivroGenero(id);
        }

        public async Task<Models.TbLivroGenero> ValidarDeletarLivroAutor(int id)
        {
            ValidarId(id);
            return await database.DeletarLivroGenero(id);
        }

        public async Task<Models.TbLivroGenero> ValidarAlterarLivroGenero(int id ,Models.TbLivroGenero tabela)
        {
            ValidarId(id);
            ValidarId(tabela.IdGenero);
            ValidarId(tabela.IdLivro);
            return await database.AlterarLivroGenero(id,tabela);
        }
    }
}