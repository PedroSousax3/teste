using System;
using System.Linq;
namespace api.Utils
{
    public class LoginConversor
    {
        Database.LoginDatabase database = new Database.LoginDatabase();
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();
        public Models.TbLogin ParaTabelaCadastrarLogin(Models.Request.LoginRequest.CadastrarLogin request)
        {
            Models.TbLogin tabela = new Models.TbLogin();
            tabela.NmUsuario = request.Usuario;
           
           if(request.Senha == request.ConfirmarSenha)
              tabela.DsSenha = request.Senha;
            else
              throw new ArgumentException("Confirmação de senha incorreta");
            
           return tabela;
        }
 
        public Models.TbLogin ParaTabelaCadastrarFuncionarioLogin(Models.Request.LoginRequest.CadastrarLoginFuncionario request)
        {
            Models.TbLogin tabela = new Models.TbLogin();
            tabela.NmUsuario = request.NomeDeUsuario;
            tabela.DsSenha = request.Senha;

            return tabela;
        }
        public Models.Response.LoginResponse.CadastrarLoginFuncionario ParaResponseCadastrarLoginResponse(Models.TbLogin tabela,Models.Request.LoginRequest.CadastrarLoginFuncionario request)
        {
           Models.Response.LoginResponse.CadastrarLoginFuncionario response = new Models.Response.LoginResponse.CadastrarLoginFuncionario();
           response.Email = request.Email;
           response.Nome = request.Nome;
           response.Id = tabela.IdLogin;
           response.Usuario = tabela.NmUsuario;
           return response;
        }

        public Models.Response.EmailResponse.RecuperarSenhar ParaResponse(Models.TbLogin tabela)
        {
            Models.Response.EmailResponse.RecuperarSenhar response = new Models.Response.EmailResponse.RecuperarSenhar();
            response.IdLogin = tabela.IdLogin;
            return response;
        }    
    }
}