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
    public class AutorController : ControllerBase
    {
        Business.AutorBusiness business = new Business.AutorBusiness();
        Business.GerenciadorFile gerenciador = new Business.GerenciadorFile();
        Utils.Conversor.AutorConversor conversor = new Utils.Conversor.AutorConversor();
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.AutorResponse>> CadastrarAutor([FromForm] Models.Request.AutorRequest request)
        {
            try
            {
                Models.TbAutor tabela = conversor.ConversorRequest(request);
                tabela.DsFoto = gerenciador.GerarNovoNome(request.foto.FileName.ToString());
                tabela = await business.ValidarCadastro(tabela);
                gerenciador.SalvarFile(tabela.DsFoto, request.foto);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400,ex.Message));
            }
        }
        [HttpPut("alterar/{idautor}")]
        public async Task<ActionResult<Models.Response.AutorResponse>> AlterarAutor([FromForm] Models.Request.AutorRequest request,int idautor)
        {
            try
            {
                Models.TbAutor tabela = conversor.ConversorRequest(request);
                tabela.DsFoto = gerenciador.GerarNovoNome(request.foto.FileName);
                tabela =  await business.ValidarAlterar(idautor,tabela);
                gerenciador.SalvarFile(tabela.DsFoto,request.foto);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<Models.Response.AutorResponse>> DeletarAutor(int id)
        {
            try
            {
                Models.TbAutor tabela = await business.ValidarDeletarAutor(id);
                Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Response.AutorResponse>> ConsultarPorIdAutor(int id)
        {
            try
            {
                Models.TbAutor tabela = await business.ValidarConsultaPorId(id);
                return conversor.ConversorResponse(tabela);
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }

        [HttpGet("listar")]
        public async Task<ActionResult<List<Models.Response.AutorResponse>>> ListarAutores()
        {
            try
            {
                List<Models.TbAutor> tabela = await business.ValidarListarAutores();
                return tabela.Select(x => conversor.ConversorResponse(x)).ToList();
            }
            catch (System.Exception ex)
            {
                return new NotFoundObjectResult(new Models.Response.ErroResponse(404,ex.Message));
            }
        }


        [HttpGet("foto/{nome}")]
        public ActionResult ConsultarArquivoPorNomeController(string nome)
        {
            try
            {
                byte[] arquivo = gerenciador.LerFile(nome);
                string extensao = gerenciador.GerarContentType(nome);
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
            
