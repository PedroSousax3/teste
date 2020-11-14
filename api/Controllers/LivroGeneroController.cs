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
    public class LivroGeneroController:ControllerBase
    {
        Utils.Conversor.LivroGeneroConversor conversor = new Utils.Conversor.LivroGeneroConversor();
        Business.LivroGeneroBusiness business = new Business.LivroGeneroBusiness();

        
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.LivroGeneroResponse>> CadastrarLivroGenero(Models.Request.LivroGeneroRequest request)
        {
            try
            {
                Models.TbLivroGenero tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarCadastrarLivroGenero(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
                
        [HttpPut("alterar/idlivrogenero")]
        public async Task<ActionResult<Models.Response.LivroGeneroResponse>> AlterarLivroGenero(int idlivrogenero,Models.Request.LivroGeneroRequest request)
        {
            try
            {
                Models.TbLivroGenero tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarAlterarLivroGenero(idlivrogenero,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
    }
}