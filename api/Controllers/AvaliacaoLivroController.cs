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
    public class AvaliacaoLivroController:ControllerBase
    {
        Utils.Conversor.AvalicaoLivroConversor conversor = new Utils.Conversor.AvalicaoLivroConversor();
        Business.AvaliacaoBusiness business = new Business.AvaliacaoBusiness();

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.AvaliacaoLivroResponse>> CadastrarAvaliacaoLivro(Models.Request.AvaliacaoLivro request)
        {
            try
            {
                Models.TbAvaliacaoLivro tabela = conversor.ConversorTabela(request);
                tabela = await business.InserirBusiness(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpPut("alterar/{idavaliacaolivro}")]
        public async Task<ActionResult<Models.Response.AvaliacaoLivroResponse>> AlterarAvaliacaoLivro(int idavaliacaolivro,Models.Request.AvaliacaoLivro request)
        {
            try
            {
                Models.TbAvaliacaoLivro tabela = conversor.ConversorTabela(request);
                tabela = await business.AlterarAvaliacaoBusiness(idavaliacaolivro,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new  NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("{idlivro}")]
        public async Task<List<Models.Response.AvaliacaoLivroResponse>> ListarController(int idlivro) 
        {
            List<Models.TbAvaliacaoLivro> avaliacao = await business.ListarAvaliacoesBusiness(idlivro);
            return avaliacao.Select(x => conversor.ConversorResponse(x)).ToList();
        }
        
    }
}