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
    public class GeneroController : ControllerBase
    {
        Business.GeneroBusiness business = new Business.GeneroBusiness();
        Utils.GeneroConversor conversor = new Utils.GeneroConversor(); 
        Business.GerenciadorFile gerenciador = new Business.GerenciadorFile();
        
        [HttpPost("cadastrar")]
         public async Task<ActionResult<Models.Response.GeneroResponse>> CadastrarGenero([FromForm] Models.Request.GeneroRequest request)
         {
             try
             {
                Models.TbGenero tabela = conversor.ParaTabelaGenero(request);
                tabela.DsFoto = gerenciador.GerarNovoNome(request.Foto.FileName);
                await business.ValidarCadastroGenero(tabela);
                gerenciador.SalvarFile(tabela.DsFoto,request.Foto);
                return conversor.ParaResponseListarGenero(tabela);
             }
             catch (System.Exception ex)
             {
                 return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
             }
         }

         [HttpPut("alterar/{idgenero}")]
         public async Task<ActionResult<Models.Response.GeneroResponse>> AlterarGenero([FromForm] Models.Request.GeneroRequest request,int idgenero)
         {
             try
             {
                 Models.TbGenero tabela = conversor.ParaTabelaGenero(request);
                 tabela.DsFoto = gerenciador.GerarNovoNome(request.Foto.FileName);
                 tabela = await business.ValidarAlterar(idgenero,tabela);
                 gerenciador.SalvarFile(tabela.DsFoto,request.Foto);
                 return conversor.ParaResponseListarGenero(tabela);
             }
             catch (System.Exception ex)
             {
                return BadRequest(new Models.Response.ErroResponse( 400,ex.Message));
             }
         }

        [HttpGet("Generos")]
        public async Task<ActionResult<List<Models.Response.GeneroResponse>>> ListarGeneros()
        {
            try
            {
               List<Models.TbGenero> tabela =await  business.ValidarListarGeneros();
               return conversor.ParaListaResponseListarGenero(tabela); 
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<Models.Response.GeneroResponse>> DeletarGenero(int id)
        {
            try
            {
                Models.TbGenero tabela = await business.DeletarGenero(id);
                return conversor.ParaResponseListarGenero(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
    }
}