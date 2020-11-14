using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmailController : ControllerBase
    {
        Business.EnviarEmailBusiness gerenciadorEmail = new Business.EnviarEmailBusiness();
        Utils.LoginConversor conversor = new Utils.LoginConversor();
        [HttpPost]
        public ActionResult EnviarEmailController(Models.Request.EmailRequest.EnvioEmailRequest request)
        {
            try
            {
                gerenciadorEmail.EnvioEmail(request.destinatario, request.titulo, request.msn);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpPost("resetar")]
        public async Task<ActionResult<Models.Response.EmailResponse.RecuperarSenhar>> ResetarSenha(Models.Request.EmailRequest.EmailRecuperarSenha request)
        {
            try
            {
                 Models.TbLogin tabela = await gerenciadorEmail.EnviarCodigoRecuperarSenha(request);
                 return conversor.ParaResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

    }
}