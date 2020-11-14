using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace api.Business
{
  public class LoginBusiness
    {
      Business.Validador.ValidadorLogin validador = new Business.Validador.ValidadorLogin();
      Database.LoginDatabase database = new Database.LoginDatabase();
      
    
      public async Task<Models.TbLogin> ValidarCadastrarLoginFuncionario(Models.TbLogin tabela ,Models.Request.LoginRequest.CadastrarLoginFuncionario request)
      {
          bool jaexiste = await database.VerificarSeOUsuarioExiste(tabela.NmUsuario);
          bool jaexisteEmail = await database.VerificarSeEmailFuncionarioExiste(request.Email);
          validador.ValidarCadastroLogin(jaexisteEmail,jaexiste,tabela.DsSenha);
          validador.ValidarConfirmarLogin(request.NomeDeUsuario,request.Senha);
          await database.CadastrarLogin(tabela);
          return tabela;
      }
      
      public async Task<Models.TbLogin> ValidarConfirmarCodigoRecuperarSenha(string codigo,int idLogin)
      {
        return await database.ConfirmarCodigoRecuperarSenha(codigo,idLogin); 
      }
      public async Task<Models.TbLogin> ValidarResetarSenha(string senha,int idLogin)
      {
         validador.ValidarSenha(senha);
         return await database.ResetarSenha(idLogin,senha);
      }
    
      public async Task<Models.TbLogin> ValidarDeletarLogin(int id)
      {
         validador.ValidarId(id);
         return await database.DeletarLogin(id);
      }
    }
}