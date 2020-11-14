namespace api.Utils.Conversor
{
    public class EnderecoConversor
    {
        public Models.TbEndereco Conversor(Models.Request.EnderecoRequest request)
        {
            Models.TbEndereco tabela = new Models.TbEndereco();

            tabela.IdCliente = request.cliente;
            tabela.NmEndereco = request.nome;
            tabela.DsEndereco = request.endereco;
            tabela.NrEndereco = request.numero;
            tabela.DsCep = request.cep;
            tabela.DsComplemento = request.complemento;
            tabela.DsCelular = request.celular;
            tabela.NmCidade = request.cidade;
            tabela.NmEstado = request.estado;

            return tabela;
        }

        public Models.Response.EnderecoResponse Conversor(Models.TbEndereco tabela)
        {
            Models.Response.EnderecoResponse response = new Models.Response.EnderecoResponse();
            response.id = tabela.IdEndereco;
            response.cliente = tabela.IdCliente;
            response.nome = tabela.NmEndereco;
            response.endereco = tabela.DsEndereco;
            response.numero = tabela.NrEndereco;
            response.cep = tabela.DsCep;
            response.complemento = tabela.DsComplemento;
            response.celular = tabela.DsCelular;
            response.cidade = tabela.NmCidade;
            response.estado = tabela.NmEstado;

            return response;
        }
    }
}