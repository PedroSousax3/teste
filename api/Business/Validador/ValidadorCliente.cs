using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Business.Validador
{
    public class ValidadorCliente : Business.Validador.ValidadorPadrao
    {
        public void ValidarCliente(Models.TbCliente tabela)
        {
            ValidarTexto(tabela.DsEmail,"E-mail");
            ValidarTexto(tabela.DsCpf,"Cpf");
            ValidarTexto(tabela.NmCliente,"Nome");
            ValidarTexto(tabela.IdLoginNavigation.NmUsuario, "Nome de usuario");
            ValidarTexto(tabela.IdLoginNavigation.DsSenha, "Senha");
            this.ValidarCadastroCliente(tabela, tabela.IdLoginNavigation);
        }
        public void ValidarClienteAlterar(Models.TbCliente tabela)
        {
            ValidarTexto(tabela.DsEmail,"E-mail");
            ValidarTexto(tabela.NmCliente,"Nome");
            ValidarTexto(tabela.TpGenero,"Genero");
            
        }

        public void ValidarCadastroCliente (Models.TbCliente tabela, Models.TbLogin login)
        {
            Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();
            foreach(Models.TbCliente item in context.TbCliente.Include(x => x.IdLoginNavigation))
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
        public void ValidarClienteExiste(int id)
        {
            ValidarId(id);
            Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();
            Models.TbCliente tabela = context.TbCliente.FirstOrDefault(x => x.IdCliente == id);
            if(tabela == null)
            throw new ArgumentException("Cliente nao encontrado");
        }
    }
}