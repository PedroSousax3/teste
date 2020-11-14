using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace api.Utils
{
    public class GeneroConversor
    {
        public Models.TbGenero ParaTabelaGenero(Models.Request.GeneroRequest request)
        {
            Models.TbGenero tabela = new Models.TbGenero();
            tabela.NmGenero = request.Nome;
            tabela.DsGenero = request.Descricao;
            return tabela;
        }
        public Models.Response.GeneroResponse ParaResponseListarGenero(Models.TbGenero tabela)
        {
            Models.Response.GeneroResponse response = new Models.Response.GeneroResponse();
            response.IdGenero = tabela.IdGenero;
            response.Genero = tabela.NmGenero;
            response.Descricao = tabela.DsGenero;
            response.Foto = tabela.DsFoto;

            return response;
        }
        public List<Models.Response.GeneroResponse> ParaListaResponseListarGenero(List<Models.TbGenero> tabela)
        {
            return tabela.Select(x => ParaResponseListarGenero(x)).ToList();
        }
    }
}