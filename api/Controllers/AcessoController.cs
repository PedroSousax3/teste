using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        Business.Acesso.AcessoBusiness business = new Business.Acesso.AcessoBusiness();
        Utils.Conversor.AcessoConversor acessoConversor = new Utils.Conversor.AcessoConversor();
        [HttpPost]
        public async Task<ActionResult<Models.Response.AcessoResponse>> Acessar(Models.Request.AcessoRequest request)
        {
            try
            {
                Models.TbLogin login = await business.ConsultarLoginBusiness(request.user, request.senha);
                string perfil;
                int idpessoa;
                if(login.TbCliente.FirstOrDefault(x => x.IdLogin == login.IdLogin) != null)
                {
                    idpessoa = login.TbCliente.FirstOrDefault(x => x.IdLogin == login.IdLogin).IdCliente;
                    perfil = "cliente";
                }
                else 
                {
                    idpessoa = login.TbFuncionario.FirstOrDefault(x => x.IdLogin == login.IdLogin).IdFuncionario;
                    perfil = "funcionario";
                }
                string token = business.GerarToken(login, idpessoa);
                
                Models.Response.AcessoResponse response = acessoConversor.Conversor(login.NmUsuario, token, idpessoa, perfil);

                return response;
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpPost("validar")]
        public async Task<ActionResult<Models.TbCliente>> ValidarUserController(Models.Response.AcessoResponse acesso)
        {
            try
            {
                Models.TbCliente cliente = await business.ValidarUser(acesso);

                return cliente;
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }
    }
}