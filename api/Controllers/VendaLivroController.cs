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
    public class VendaLivroController:ControllerBase
    {
        Utils.Conversor.VendaLivroConversor conversor = new Utils.Conversor.VendaLivroConversor();
        Business.VendaLivro business = new Business.VendaLivro();

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.VendaLivroResponse>> CadastrarVendaLivro(Models.Request.VendaLivroRequest request)
        {
            try
            {
                Models.TbVendaLivro tabela = conversor.ConversorTabela(request);
                tabela = await business.CadastrarBusiness(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpPut("alterar/{idvendalivro}")]
        public async Task<ActionResult<Models.Response.VendaLivroResponse>> AlterarVendaLivro(int idvendalivro,Models.Request.VendaLivroRequest request)
        {
            try
            {
                Models.TbVendaLivro tabela = conversor.ConversorTabela(request);
                tabela = await business.AlterarVendaLivroBusiness(idvendalivro,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("TopVendas")]
        public async Task<ActionResult<List<Models.Response.Top10Vendas>>> ListarVendas()
        {
            try
            {
                List<Models.TbVendaLivro> tabela = await business.ListarTop10Vendas();
                if(tabela.Count == 0)
                {
                    throw new ArgumentException("Não há registros");
                }
                return conversor.ParaResponseTop10Vendas(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
        
    }
}