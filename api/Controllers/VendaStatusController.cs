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
    public class VendaStatusController:ControllerBase
    {
        Utils.Conversor.VendaLivroConversor conversorVendaLivro = new Utils.Conversor.VendaLivroConversor();
        Utils.Conversor.VendaStatusConversor conversor = new Utils.Conversor.VendaStatusConversor();
        Business.VendaStatusBusiness business = new Business.VendaStatusBusiness();
        Business.VendaLivro businesslivro = new Business.VendaLivro();
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.VendaStatusResponse>> CadastrarVendaStatus(Models.Request.VendaStatusRequest request)
        {
            try
            {
                Models.TbVendaStatus tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarCadastrarVendaStatus(tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpPut("cancelar/{idstatusvenda}")]
        public async Task<ActionResult<Models.Response.VendaStatusResponse>> AlterarStatusVenda(int idstatusvenda)
        {
            try
            {
                Models.TbVendaStatus tabela = await business.ValidarAlterarVendaStatus(idstatusvenda);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("pendentes/{idCliente}")]
        public async Task<ActionResult<List<Models.Response.RealizarVendaResponse>>> ListarPendentes(int idCliente)
        {
            try
            {
                List<Models.TbVendaStatus> tabela = await business.ListarPendentes(idCliente);
                List<Models.Response.RealizarVendaResponse> response =tabela.Select(x => conversor.ParaResponseRealizarVenda(x)).ToList();
                  foreach(Models.Response.RealizarVendaResponse item in response)
                  {
                      List<Models.TbVendaLivro> livros = await businesslivro.ConsultarVendaLivroPorIdVenda(item.IdVenda); 
                      item.VendaLivro = livros.Select(x => conversorVendaLivro.ConversorResponse(x)).ToList();
                  }
                  if(tabela.Count == 0)
                    return new NotFoundObjectResult(new Models.Response.ErroResponse(404,"Não há nenhuma compra pendente"));

                return response;
            }
            catch (System.Exception ex)
            {
                 return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("finalizadas/{idCliente}")]
        public async Task<ActionResult<List<Models.Response.RealizarVendaResponse>>> ListarFinalizadas(int idCliente)
        {
            try
            {
                List<Models.TbVendaStatus> tabela = await business.ListarFinalizadas(idCliente);
                 List<Models.Response.RealizarVendaResponse> response =tabela.Select(x => conversor.ParaResponseRealizarVenda(x)).ToList();
                  foreach(Models.Response.RealizarVendaResponse item in response)
                  {
                      List<Models.TbVendaLivro> livros = await businesslivro.ConsultarVendaLivroPorIdVenda(item.IdVenda); 
                      item.VendaLivro = livros.Select(x => conversorVendaLivro.ConversorResponse(x)).ToList();
                  }
                  if(tabela.Count == 0)
                    return new NotFoundObjectResult(new Models.Response.ErroResponse(404,"Não há nenhuma compra finalizada"));

                return response;
            }
            catch (System.Exception ex)
            {
                 return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("andamento/{idCliente}")]
        public async Task<ActionResult<List<Models.Response.RealizarVendaResponse>>> ListarEmAndamento(int idCliente)
        {
            try
            {
                List<Models.TbVendaStatus> tabela = await business.ListarEmAndamento(idCliente);
                 List<Models.Response.RealizarVendaResponse> response =tabela.Select(x => conversor.ParaResponseRealizarVenda(x)).ToList();
                  foreach(Models.Response.RealizarVendaResponse item in response)
                  {
                      List<Models.TbVendaLivro> livros = await businesslivro.ConsultarVendaLivroPorIdVenda(item.IdVenda); 
                      item.VendaLivro = livros.Select(x => conversorVendaLivro.ConversorResponse(x)).ToList();
                  }
                  if(tabela.Count == 0)
                    return new NotFoundObjectResult(new Models.Response.ErroResponse(404,"Não há nenhuma compra em andamento"));

                return response;
            }
            catch (System.Exception ex)
            {
                 return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
                      
        }
    }
}