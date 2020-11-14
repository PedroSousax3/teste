using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace api.Business
{
    public class GeneroBusiness
    {
        Database.GeneroDatabase database = new Database.GeneroDatabase();
        Validador.ValidadorGenero validador = new Validador.ValidadorGenero(); 
        public async Task<Models.TbGenero> ValidarCadastroGenero(Models.TbGenero tabela)
        {
            bool jaexiste = await database.VerificarGeneroJaExiste(tabela.NmGenero);
            validador.ValidaGenero(jaexiste,tabela);
            return await database.CadastrarGenero(tabela);
        }
        public async Task<Models.TbGenero> ValidarAlterar(int id,Models.TbGenero tabela)
        {
            bool jaexiste = await database.VerificarGeneroJaExiste(tabela.NmGenero);
            validador.ValidaGenero(jaexiste,tabela);
            return await database.AlterarGenero(id,tabela);
        } 
        public async Task<List<Models.TbGenero>> ValidarListarGeneros()
        {
           List<Models.TbGenero> tabela = await database.ListarGeneros();
           validador.ValidarListaGenero(tabela);
           return await database.ListarGeneros();
        }
        public Task<Models.TbGenero> ValidarConsultaPorID(int id)
        {
            validador.ValidarIdGenero(id);
            return database.ConsultarGeneroPorId(id);
        }
        public async Task<Models.TbGenero> DeletarGenero(int id)
        {
            validador.ValidarIdGenero(id);
            return await database.DeletarGenero(id);
        }
    }
}