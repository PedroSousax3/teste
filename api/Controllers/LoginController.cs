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
    public class LoginController:ControllerBase
    {
        Business.LoginBusiness business = new Business.LoginBusiness();
        Utils.LoginConversor conversor = new Utils.LoginConversor();
        Business.GerenciadorFile gerenciadorFoto = new Business.GerenciadorFile();

        [HttpPost("funcionario")]
        public async Task<ActionResult<Models.Response.LoginResponse.CadastrarLoginFuncionario>> CadastrarFuncionario(Models.Request.LoginRequest.CadastrarLoginFuncionario request)
        {
            try
            {
                Models.TbLogin tabela = conversor.ParaTabelaCadastrarFuncionarioLogin(request);
                tabela = await business.ValidarCadastrarLoginFuncionario(tabela,request);
                return conversor.ParaResponseCadastrarLoginResponse(tabela,request);
            }
           catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
         
        }
        [HttpPost("codigo/{idLogin}")]
        public async Task<ActionResult<Models.Response.EmailResponse.RecuperarSenhar>> ConfirmarCodigo(int idLogin,Models.Request.LoginRequest.RecuperarSenha request)
        {
            try
            {
                Models.TbLogin tabela = await business.ValidarConfirmarCodigoRecuperarSenha(request.Codigo,idLogin);
                return conversor.ParaResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpPut("novaSenha/{idLogin}")]
        public async Task<ActionResult> ResetarSenha(int idLogin,Models.Request.LoginRequest.ResetarSenha request)
        {
            try
            {
                Models.TbLogin tabela = await business.ValidarResetarSenha(request.Senha,idLogin);
                return Ok();   
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }

        [HttpGet("foto/{nome}")]
        public ActionResult BuscarFoto(string nome)
        {
            try 
            {
                byte[] foto = gerenciadorFoto.LerFile(nome);
                string contentType = gerenciadorFoto.GerarContentType(nome);
                return File(foto, contentType);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(404, ex.Message));
            }
        }
    }
}