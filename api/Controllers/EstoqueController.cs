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
    public class EstoqueController:ControllerBase
    {
        Utils.Conversor.EstoqueConvert conversor = new Utils.Conversor.EstoqueConvert();
        Business.EstoqueBusiness business = new Business.EstoqueBusiness();
        [HttpPost("Cadastrar")]
        public async Task<ActionResult<Models.Response.EstoqueResponce>> CadastrarEstoque(Models.Request.EstoqueRequest request)
        {
            try
            {
                Models.TbEstoque tabela = conversor.ConversorTabela(request);
                tabela = await business.InserirBusiness(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }
        [HttpPut("alterar/{idestoque}")]
        public async Task<ActionResult<Models.Response.EstoqueResponce>> AlterarEstoque(int idestoque,Models.Request.EstoqueRequest request)
        {
            try
            {
                Models.TbEstoque tabela = conversor.ConversorTabela(request);
                tabela = await business. AlterarBusiness(idestoque,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
    }
}