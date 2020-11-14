using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models.Response;
using api.Models.Request;
using api.Models;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnderecoController : ControllerBase
    {
        Utils.Conversor.EnderecoConversor ConversorEndereco = new Utils.Conversor.EnderecoConversor();
        Business.EnderecoBusiness business = new Business.EnderecoBusiness();
        [HttpPost]
        public async Task<ActionResult<EnderecoResponse>> InserirEnderecoController(Models.Request.EnderecoRequest novo)
        {
            try
            {
                TbEndereco endereco = ConversorEndereco.Conversor(novo);
                TbEndereco result = await business.InserirEnderecoDatabase(endereco);
                EnderecoResponse response = ConversorEndereco.Conversor(result);

                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new ErroResponse(400, ex.Message)
                );
            }
        }

        public async Task<ActionResult<EnderecoResponse>> ConsultarEnderecoPorId(int idendereco)
        {
            try
            {
                TbEndereco endereco = await business.ConsultarEnderecoPorId(idendereco);
                return ConversorEndereco.Conversor(endereco);
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new ErroResponse(400, ex.Message)
                );
            }
        }
        
        [HttpGet("{cliente}")]
        public async Task<ActionResult<List<Models.Response.EnderecoResponse>>> ListarEnderecoClienteDatabase(int cliente)
        {
            try 
            {
                List<Models.TbEndereco> enderecos = await business.ListarEnderecoClienteDatabase(cliente);
                return enderecos.Select(x => ConversorEndereco.Conversor(x)).ToList();
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new ErroResponse(404, ex.Message)
                );
            }
        }

        public async Task<ActionResult<EnderecoResponse>> AlterarEnderecoController(int idendereco, EnderecoRequest novo)
        {
            try
            {
                TbEndereco endereco = ConversorEndereco.Conversor(novo);
                TbEndereco result = await business.AlterarEndereco(idendereco, endereco);
                EnderecoResponse response = ConversorEndereco.Conversor(result);

                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new ErroResponse(400, ex.Message)
                );
            }
        }

        public async Task<ActionResult<EnderecoResponse>> RemoverEndereco(int idendereco)
        {
            try
            {
                TbEndereco result = await business.RemoverEnderecoPorId(idendereco);
                EnderecoResponse response = ConversorEndereco.Conversor(result);

                return response;
            }
            catch (System.Exception ex)
            {
                return NotFound(
                    new ErroResponse(400, ex.Message)
                );
            }
        }
    }
}