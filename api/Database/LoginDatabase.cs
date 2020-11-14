using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Collections;
using System.Linq;
using System;
namespace api.Database
{
    public class LoginDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();


        //recuperar senha etapa1
        public async Task<Models.TbLogin> VerificarEmailRecuperarSenha(Models.Request.EmailRequest.EmailRecuperarSenha request,string codigo)
        {
            Models.TbLogin login = new Models.TbLogin();  
            Models.TbCliente tabela =  context.TbCliente.Include(x => x.IdLoginNavigation)
                                            .FirstOrDefault(x => x.DsEmail == request.Email);
            
            Models.TbFuncionario tabelaFuncionario = context.TbFuncionario.Include(x =>x.IdLoginNavigation)
                                                            .FirstOrDefault(x => x.DsEmail == request.Email); 
            if(tabela != null)
               {
                   tabela.IdLoginNavigation.DsCodigoVerificacao = codigo;
                   tabela.IdLoginNavigation.DtCodigoVerificacao = DateTime.Now;
                   login = await ConsultarLoginPorId(tabela.IdLogin);
               }

            else if(tabelaFuncionario != null)
            {
                 tabelaFuncionario.IdLoginNavigation.DsCodigoVerificacao = codigo;
                 tabelaFuncionario.IdLoginNavigation.DtCodigoVerificacao = DateTime.Now;
                 login = await ConsultarLoginPorId(tabelaFuncionario.IdLogin);
            }

            else {
                throw new ArgumentException("Esse email ainda não esta cadastrado.");
            }
             await context.SaveChangesAsync();
             return login;

        }
        
        //etapa2
      public async Task<Models.TbLogin> ConfirmarCodigoRecuperarSenha(string codigo,int idLogin)
      {
          Models.TbLogin tabela = await ConsultarLoginPorId(idLogin);
          if(tabela.DsCodigoVerificacao != codigo)
             throw new ArgumentException("Codigo inválido");
          if(tabela.DtCodigoVerificacao.Value.AddHours(2) < DateTime.Now)
             throw new ArgumentException("Esse codigo já expirou");

          return tabela;
      }

      //etapa3
      public async Task<Models.TbLogin> ResetarSenha(int id,string senha)
      {
          Models.TbLogin tabela = await ConsultarLoginPorId(id);
          tabela.DsSenha = senha;
          await context.SaveChangesAsync();
          return tabela;
      }

       ///cadastro
        public async Task<Models.TbLogin> CadastrarLogin(Models.TbLogin tabela)
        {
            await context.TbLogin.AddAsync(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }
        
        public async Task<bool> VerificarSeOUsuarioExiste(string usuario)
        {
            Models.TbLogin tabela = await context.TbLogin.FirstOrDefaultAsync(x => x.NmUsuario == usuario);
            bool resposta = true;
            if(tabela == null)
                  resposta = false;
               return resposta;
        }
        public async Task<bool> VerificarSeEmailExiste(string usuario)
        {
            Models.TbCliente tabelaCliente = await context.TbCliente.FirstOrDefaultAsync(x => x.DsEmail == usuario);
            bool resposta = true;
            if(tabelaCliente  == null)
              resposta = false;
            return resposta;
        }
        public async Task<bool> VerificarSeEmailFuncionarioExiste(string usuario)
        {
            Models.TbFuncionario tabelaFuncionario = await context.TbFuncionario.FirstOrDefaultAsync(x => x.DsEmail == usuario);
            bool resposta = true;
            if(tabelaFuncionario  == null)
              resposta = false;
            return resposta;
        }

        //padrao
         public Task<Models.TbLogin> ConsultarLoginPorId(int id)
         {
            return context.TbLogin.FirstOrDefaultAsync(x => x.IdLogin == id);
         }
         public async Task<Models.TbLogin> DeletarLogin(int id)
         {
             Models.TbLogin tabela = await ConsultarLoginPorId(id);
             context.TbLogin.Remove(tabela);
             await context.SaveChangesAsync();
             return tabela;
         }
         public async Task<Models.TbLogin> AlterarLogin(int id,Models.TbLogin novaTabela)
         {
             Models.TbLogin tabela = await ConsultarLoginPorId(id);
             tabela.NmUsuario = novaTabela.NmUsuario;
             tabela.DsSenha = novaTabela.DsSenha;
             await context.SaveChangesAsync();
             return tabela;
         }
         public Task<List<Models.TbLogin>> ListarLogin()
         {
             return context.TbLogin.ToListAsync();
         }
        //
        
    }
}