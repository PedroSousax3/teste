using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace api.Business.Validador
{
    public class ValidadorFuncionario:Validador.ValidadorPadrao
    {
        public void ValidarFuncionario(Models.TbFuncionario tabela)
        {
            ValidarTexto(tabela.DsEmail,"E-mail");
            ValidarTexto(tabela.DsCpf,"Cpf");
            ValidarTexto(tabela.NmFuncionario,"Nome");
            ValidarTexto(tabela.IdLoginNavigation.NmUsuario, "Nome de usuario");
            ValidarTexto(tabela.IdLoginNavigation.DsSenha, "Senha");
            this.ValidarCadastroFuncionario(tabela, tabela.IdLoginNavigation);
        }

        public void ValidarCadastroFuncionario (Models.TbFuncionario tabela, Models.TbLogin login)
        {
            Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();
            foreach(Models.TbFuncionario item in context.TbFuncionario.Include(x => x.IdLoginNavigation))
            {
                if(tabela.DsEmail == item.DsEmail)
                    throw new ArgumentException("E-mail já cadastrado.");
                if(tabela.DsCpf == item.DsCpf)
                    throw new ArgumentException("CPF já cadastrado.");
                if(login.NmUsuario == item.IdLoginNavigation.NmUsuario)
                    throw new ArgumentException("Nome de usuario já cadastrado. Tente outro nome");
                if(login.NmUsuario == item.IdLoginNavigation.NmUsuario)
                    throw new ArgumentException("Nome de usuario já cadastrado. Tente outro nome");
            }
            new ValidadorLogin().ValidarSenha(login.DsSenha);
        }
    }
}