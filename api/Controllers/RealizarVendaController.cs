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
    public class RealizarVendaController:ControllerBase
    {
        Business.VendaBusiness business = new Business.VendaBusiness();
        Business.EstoqueBusiness estoquebusiness = new Business.EstoqueBusiness();
        Business.CarrinhoBusiness carrinhobusiness = new Business.CarrinhoBusiness();
        Utils.Conversor.RealizarCompraConversor conversor = new Utils.Conversor.RealizarCompraConversor();
        [HttpPost]
        public async Task<ActionResult> RealizarVenda(Models.Request.RealizarVendaRequest.RealizarVendaPersonalizado request)
        {
            try
            {
                Models.TbVenda tabela = conversor.ParaTabelaVenda(request);
                await estoquebusiness.RetirarQuantidadeVendidaBusiness(tabela.TbVendaLivro.ToList());
                carrinhobusiness.ValidarRetirarDoCarrinho(request.IdCliente);
                tabela = await business.InserirBusiness(tabela);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }

        }
        
    }
}