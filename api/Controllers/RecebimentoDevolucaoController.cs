using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RecebimentoDevolucaoController:ControllerBase
    {
        Utils.Conversor.RecebimentoDevolucaoConversor conversor = new Utils.Conversor.RecebimentoDevolucaoConversor();
        Business.RecebimentoDevolucaoBusiness business = new Business.RecebimentoDevolucaoBusiness();

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.ReciboDevolucaoResponse>> CadastrarRecebimnetoDevolucao(Models.Request.ReciboDevolucaoRequest request)
        {
            try
            {
                Models.TbRecebimentoDevolucao tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarInserirRecebimentoDevolucao(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }
        [HttpPut("alterar/{idrecebimentodevolucao}")]
        public async Task<ActionResult<Models.Response.ReciboDevolucaoResponse>> AlterarRecebimentoDevolucao(int idrecebimentodevolucao,Models.Request.ReciboDevolucaoRequest request)
        {
            try
            {
                Models.TbRecebimentoDevolucao tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarAlterarRecebimentoDevolucao(idrecebimentodevolucao,tabela);
                return conversor.ConversorResponse(tabela); 
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
    }
}