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
    public class ClienteController : ControllerBase
    {
        Business.GerenciadorFile gerenciadorFoto = new Business.GerenciadorFile();
        Business.EnviarEmailBusiness gerenciadorEmail = new Business.EnviarEmailBusiness();
        Business.ClienteBusiness business = new Business.ClienteBusiness();
        Utils.ClienteConversor conversor = new Utils.ClienteConversor();

        [HttpPost]
        public async Task<ActionResult<Models.Response.AcessoResponse>> CadastrarCliente([FromForm] Models.Request.ClienteRequest.CadastroCliente request)
        {
            try
            {
                //Converte 
                Models.TbCliente tabela = conversor.Conversor(request);
                if (request.foto == null)
                    tabela.DsFoto = "";
                else
                    tabela.DsFoto = gerenciadorFoto.GerarNovoNome(request.foto.FileName);
                //Salva no Banco de dados e o arquivo
                Models.TbCliente cliente = await business.CadastrarCliente(tabela);
                if (request.foto != null)
                    gerenciadorFoto.SalvarFile(tabela.DsFoto, request.foto);
                //Envia o e-mail
                string corpo = $"<div><h2>Bem vindo {cliente.NmCliente} a Next Gen Books!</h2><div> <div><p>Aqui você poderá encontrar a maior variedade de livros para que já viu, para todos os tipos de leitores<p><div><div><a href=`3.87.226.24:3000`>Acesse o nosso site</a></div>";
                gerenciadorEmail.EnvioEmail(cliente.DsEmail, "Bem Vindo " + cliente.NmCliente + " a Next Gen Books!!!", corpo);
                //Gera um token
                Business.Acesso.AcessoBusiness gerartoken = new Business.Acesso.AcessoBusiness();
                Utils.Conversor.AcessoConversor acessoConversor = new Utils.Conversor.AcessoConversor();
                string token = gerartoken.GerarToken(cliente.IdLoginNavigation, cliente.IdCliente);

                return acessoConversor.Conversor(cliente.IdLoginNavigation.NmUsuario, token, cliente.IdCliente, "cliente");
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpPut("{idcliente}")]
        public async Task<ActionResult<Models.Response.ClienteResponse>> CadastrarCliente(int idcliente, [FromForm] Models.Request.ClienteRequest.Cliente request)
        {
            try
            {
                Models.TbCliente tabela = conversor.ParaTabelAlteraCliente(request);
                
                if (request.foto == null)
                    tabela.DsFoto = "";
                else
                    tabela.DsFoto = gerenciadorFoto.GerarNovoNome(request.foto.FileName);

                tabela = await business.AlterarCliente(idcliente, tabela);
                if(request.foto != null)
                    gerenciadorFoto.SalvarFile(tabela.DsFoto, request.foto);
                return conversor.ParaResponseCliente(tabela);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new Models.Response.ErroResponse(400, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<Models.Response.ClienteResponse> ConsultarCliente(int id)
        {
            Models.TbCliente cliente = await business.ValidarConsultaPorId(id);
            return conversor.ParaResponseCliente(cliente);
        }

        [HttpGet("foto/{nome}")]
        public ActionResult ConsultarArquivoPorNomeController(string nome)
        {
            try
            {
                byte[] arquivo = gerenciadorFoto.LerFile(nome);
                string extensao = gerenciadorFoto.GerarContentType(nome);
                return File(arquivo, extensao);
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