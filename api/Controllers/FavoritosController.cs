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
    public class FavoritosController:ControllerBase
    {
        Utils.Conversor.FavoritoConversor conversor = new Utils.Conversor.FavoritoConversor();
        Business.FavoritosBusiness business = new Business.FavoritosBusiness();
        
        [HttpPost]
        public async Task<ActionResult> InserirFavarito(Models.Request.FavoritoRequest request)
        {
            try
            {
                Models.TbFavoritos tabela = conversor.ConversorTabela(request);
                tabela = await business.InserirBusiness(tabela);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpGet("{idcliente}")]
        public async Task<ActionResult<List<Models.Response.FavoritoResponse>>> Listar (int idcliente)
        {
            try
            {
                List<Models.TbFavoritos> favoritos = await business.ListarfavoritosBusiness(idcliente);
                return favoritos.Select(x => conversor.ConversorResponse(x)).ToList();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpDelete]
        public async Task<ActionResult> RemoverFavorito(int idfavorito)
        {
            try
            {
                Models.TbFavoritos favorito = await business.RemoverFavoritosPorId(idfavorito);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpPut("alterar/{idfavorito}")]
        public async Task<ActionResult<Models.Response.FavoritoResponse>> AlterarResponse(int idfavorito,Models.Request.FavoritoRequest request)
        {
            try
            {
                Models.TbFavoritos tabela = conversor.ConversorTabela(request);
                tabela = await business.AlterarFavoritosPorId(idfavorito,tabela);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
        
    }
}