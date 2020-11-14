using System;

namespace api.Utils
{
    public class ClienteConversor
    {
        public Models.TbCliente Conversor (Models.Request.ClienteRequest.CadastroCliente request)
        {
            Models.TbCliente tabela = new Models.TbCliente();
            //Cliente
            tabela.DsCpf = request.cpf;
            tabela.DsEmail = request.email;
            tabela.NmCliente = request.nome;
            tabela.DsCelular =  request.celular;
            tabela.TpGenero = request.genero;
            tabela.DtNascimento = request.Nascimento;
            //Login
            Models.TbLogin login = new Models.TbLogin();
            login.NmUsuario = request.usuario;
            login.DsSenha = request.senha;
            login.DtUltimoLogin = DateTime.Now;
            tabela.IdLoginNavigation = login;

            return tabela;
        }
        public Models.TbCliente ParaTabelAlteraCliente(Models.Request.ClienteRequest.Cliente request)
        {
            Models.TbCliente tabela = new Models.TbCliente();

            tabela.DsEmail = request.email;
            tabela.NmCliente = request.nome;
            tabela.DsCelular = request.celular;
            tabela.TpGenero = request.genero;
            tabela.DtNascimento = request.nascimento;

            return tabela;
        }
        public Models.Response.ClienteResponse ParaResponseCliente(Models.TbCliente tabela)
        {
            Models.Response.ClienteResponse response = new Models.Response.ClienteResponse();

            response.IdCliente = tabela.IdCliente;
            response.Nome = tabela.NmCliente;
            response.Genero = tabela.TpGenero;
            response.Email = tabela.DsEmail;
            response.Celular = tabela.DsCelular;
            response.Foto = tabela.DsFoto;
            response.Nascimento = tabela.DtNascimento;

            return response;
        }
    }
}