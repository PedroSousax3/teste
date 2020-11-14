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
    public class CarrinhoController:ControllerBase
    {
        Utils.Conversor.CarrinhoConversor conversor = new Utils.Conversor.CarrinhoConversor();
        Business.CarrinhoBusiness business = new Business.CarrinhoBusiness();
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.CarrinhoResponse>> CadastrarCarrinho(Models.Request.CarrinhoRequest request)
        {
            try
            {
                Models.TbCarrinho tabela = conversor.ConversorTabela(request);
                tabela = await business.ValidarInserirCarrinho(tabela); 
                return conversor.ConversorResponseLite(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet]
        public ActionResult<List<Models.Response.CarrinhoResponse>> ListarCarrinhoCliente(int idcliente) 
        {
            try 
            {
                List<Models.TbCarrinho> carrinho =  business.ValidarListarCarrinhoCliente(idcliente);

                return carrinho.Select(x => conversor.ConversorResponse(x)).ToList();
            }
            catch (System.Exception ex) 
            {
                return NotFound(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpPut("alterar/{idcarrinho}")]
        public async Task<ActionResult> AlterarCarrinho(int idcarrinho, int newqtd)
        {
            try
            {
                await business.ValidarAlteracaoCarrinho(idcarrinho, newqtd);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                await business.ValidarDeletarCarrinho(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new Models.Response.ErroResponse(404,ex.Message)
                );
            }
        }

    }
}