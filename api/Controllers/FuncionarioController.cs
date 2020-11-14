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
    public class FuncionarioController:ControllerBase
    {
        Utils.Conversor.FuncionarioConversor conversor = new Utils.Conversor.FuncionarioConversor();
        Business.FuncionarioBusiness business = new Business.FuncionarioBusiness();

        [HttpPost]
        public async Task<ActionResult<Models.Response.AcessoResponse>> InserirController(Models.Request.FuncionarioRequest novo)
        {
            try
            {
                Models.TbFuncionario funcionario = conversor.ConversorFuncionarioTabela(novo);
                Models.TbFuncionario result = await business.CadastrarBusiness(funcionario);
                Business.Acesso.AcessoBusiness gerartoken = new Business.Acesso.AcessoBusiness();
                Utils.Conversor.AcessoConversor acessoConversor = new Utils.Conversor.AcessoConversor();
                string token = gerartoken.GerarToken(result.IdLoginNavigation,result.IdFuncionario);
                
                return acessoConversor.Conversor(result.IdLoginNavigation.NmUsuario, token, result.IdFuncionario, "funcionario");
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpPut("alterar/{idfuncionario}")]
        public async Task<ActionResult<Models.Response.FuncionarioResponse>> AlterarFuncionario(int idfuncionario,Models.Request.FuncionarioRequest request)
        {
            try
            {
                Models.TbFuncionario tabela = conversor.ConversorFuncionarioTabela(request);
                tabela = await business.AlterarBusiness(idfuncionario,tabela);
                return conversor.ConversorFuncionarioResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
        
    }
}