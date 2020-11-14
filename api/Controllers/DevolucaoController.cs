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
    public class DevolucaoController : ControllerBase
    {
        Utils.Conversor.DevolucaoConversor conversor = new Utils.Conversor.DevolucaoConversor();
        Business.DevolucaoBusiness business = new Business.DevolucaoBusiness();
        Business.VendaLivro devolver = new Business.VendaLivro();
        Business.GerenciadorFile gerenciadorFoto = new Business.GerenciadorFile();
        
        [HttpPost]
        public async Task<ActionResult<Models.Response.DevolucaoResponse>> CadastrarDevolucao([FromForm] Models.Request.DevolucaoRequest request)
        {
            try
            {
                Models.TbDevolucao tabela = conversor.ConversorTabela(request);
                tabela.DsComprovante = gerenciadorFoto.GerarNovoNome(request.comprovante.FileName);
                tabela = await business.ValidarCadastrarDevoucao(tabela);
                gerenciadorFoto.SalvarFile(tabela.DsComprovante, request.comprovante);
                await devolver.AlterarDevolvido(tabela.IdVendaLivro);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpPut("alterar/{iddevolucao}")]
        public async Task<ActionResult<Models.Response.DevolucaoResponse>> AlterarDevolucao(int iddevolucao,Models.Request.DevolucaoRequest request)
        {
            try
            {
                Models.TbDevolucao tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarAlterarDevolucao(iddevolucao,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.TbDevolucao>>> ConsultarDevolucoesPorPeriodo(DateTime inicio, DateTime fim) 
        {
            try 
            {
                List<Models.TbDevolucao> tabela = await business.ValidarListarDevolucao(inicio, fim);
                return tabela;
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