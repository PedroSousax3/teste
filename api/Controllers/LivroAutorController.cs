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
    public class LivroAutorController:ControllerBase
    {
        Utils.Conversor.LivroAutorConversor conversor = new Utils.Conversor.LivroAutorConversor();
        Business.LivroAutorBusiness business = new Business.LivroAutorBusiness();

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.LivroAutorResponse>> CadastrarLivroAutor(Models.Request.LivroAutorRequest request)
        {
            try
            {
                Models.TbLivroAutor tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarCadastroLivroAutor(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpPut("alterar/{idlivroautor}")]
        public async Task<ActionResult<Models.Response.LivroAutorResponse>> AlterarLivroAutor(int idlivroautor,Models.Request.LivroAutorRequest request)
        {
            try
            {
                Models.TbLivroAutor tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarAlterarLivroAutor(idlivroautor,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
        
    }
}