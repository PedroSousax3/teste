namespace api.Utils.Conversor
{
    public class FuncionarioConversor
    {
        public Models.TbFuncionario ConversorFuncionarioTabela(Models.Request.FuncionarioRequest request)
        {
            Models.TbFuncionario tabela = new Models.TbFuncionario();
            tabela.NmFuncionario = request.nome;
            tabela.DsCarteiraTrabalho = request.carteiratrabalho;
            tabela.DsCpf = request.cpf;
            tabela.DsEmail = request.email;
            tabela.DtNascimento = request.nascimento;
            tabela.DtAdmissao = request.admissao;
            tabela.DsCargo = request.cargo;
            tabela.DsEndereco = request.endereco;
            tabela.DsCep = request.cep;
            tabela.NrResidencial = request.numeroresidencial;
            tabela.DsComplemento = request.complemento;

            Models.TbLogin login = new Models.TbLogin();
            login.NmUsuario = request.nomedeusuario;
            login.DsSenha = request.senha;

            tabela.IdLoginNavigation = login;

            return tabela;
        }

        public Models.Response.FuncionarioResponse ConversorFuncionarioResponse(Models.TbFuncionario tabela)
        {
            Models.Response.FuncionarioResponse response = new Models.Response.FuncionarioResponse();
            
            response.id = tabela.IdFuncionario;
            response.login = tabela.IdLogin;
            response.nome = tabela.NmFuncionario;
            response.carteiratrabalho = tabela.DsCarteiraTrabalho;
            response.cpf = tabela.DsCpf;
            response.email = tabela.DsEmail;
            response.nascimento = tabela.DtNascimento;
            response.admissao = tabela.DtAdmissao;
            response.cargo = tabela.DsCargo;
            response.endereco = tabela.DsEndereco;
            response.cep = tabela.DsCep;
            response.numeroresidencial = tabela.NrResidencial;
            response.complemento = tabela.DsComplemento;

            return response;
        }
    }
}