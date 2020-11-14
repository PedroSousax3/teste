using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Business
{
    public class EditoraBusiness : Database.EditoraDatabase
    {
        public async Task<Models.TbEditora> InserirEditoraBuseness(Models.TbEditora editora)
        {
            if(string.IsNullOrEmpty(editora.NmEditora))
                throw new ArgumentException("Nome da editora não foi informado.");
            if(editora.DtFundacao == null)
                throw new ArgumentException("Data de fundações da editora não foi informada");
            
            return await InserirEditora(editora);
        }

        public async Task<List<TbEditora>> ListarEditorasBusiness()
        {
            return await ListarEditoras();
        }

        public async Task<TbEditora> ConsultarEditoraPorIdBusiness(int id)
        {
            if(id <= 0)
                throw new ArgumentException("Editora informado não é valido.");
            return await ConsultarEditoraPorId(id);
        }

        public async Task<TbEditora> AlterarEditoraBusiness(int id, Models.TbEditora novo)
        {
            return await AlterarEditora(id, novo);
        }

        public async Task<TbEditora> RemoverEditoraBusiness(int id)
        {
            if(id <= 0)
                throw new ArgumentException("Editora informado não é valido.");
            return await RemoverEditora(id);
        }
    }
}