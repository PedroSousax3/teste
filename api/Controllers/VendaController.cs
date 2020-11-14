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
    public class VendaController:ControllerBase
    {
        Utils.Conversor.VendaConversor conversor = new Utils.Conversor.VendaConversor();
        Business.VendaBusiness business = new Business.VendaBusiness();
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.VendaResponse>> CadastrarVenda(Models.Request.VendaRequest request)
        {
            try
            {
                Models.TbVenda tabela = conversor.ConversorTabela(request);
                tabela = await business.InserirBusiness(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpPut("alterar/{idvenda}")]
        public async Task<ActionResult<Models.Response.VendaResponse>> AlterarVenda(int idvenda,Models.Request.VendaRequest request)
        {
            try
            {
                Models.TbVenda tabela = conversor.ConversorTabela(request);
                tabela = await business.AlterarBusinesss(idvenda,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("vendadia")]
        public async Task<ActionResult<List<Models.Response.RelatorioQuantidadeVenda>>> RelatorioVendaPorDia(DateTime Dia)
        {
            try
            {
                List<Models.TbVenda> tabela = await  business.ValidarListarVendaPorDia(Dia);

                if(tabela.Count == 0)
                {
                    throw new ArgumentException("Não há nenhum registro de vendas na data solicitada");
                }
                return tabela.Select(x => conversor.RelatorioVendaPorDiaResponse(x)).ToList();
            }
            catch (System.Exception ex)
            {
                
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("PorMes")]
        public async Task<ActionResult<List<Models.Response.VendasPorMesRelatorio>>> ListarPorMes(DateTime mesInicio,DateTime mesFim)        {
            try
            {
                List<Models.TbVenda> tabela = await business.ValidarListarPorMes(mesInicio,mesFim);
                return conversor.ParaResponseRelatorioPorMes(mesInicio,mesFim,tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
        

       [HttpGet("TopClientes")]
        public async Task<ActionResult<List<Models.Response.RelatorioTop10Clientes>>> ListarTopClientes()
        {
            try
            {
                List<Models.TbVenda> tabela = await business.ListarTop10Clientes();
                if(tabela.Count == 0)
                {
                    throw new ArgumentException("Não há registros");
                }
                return conversor.ParaResponseTopClientes(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }


    }
}