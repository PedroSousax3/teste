using System.Linq;

namespace api.Utils.Conversor
{
    public class AcessoConversor
    {
        public Models.Response.AcessoResponse Conversor (string user, string token, int idpessoa, string perfil)
        {
            Models.Response.AcessoResponse response = new Models.Response.AcessoResponse();
            
            response.nome = user;
            response.token = token;
            response.id = idpessoa;
            response.perfil = perfil;
    
            return response;
        }
    }
}