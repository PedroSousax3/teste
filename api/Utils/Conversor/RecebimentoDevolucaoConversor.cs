namespace api.Utils.Conversor
{
    public class RecebimentoDevolucaoConversor
    {
        public Models.TbRecebimentoDevolucao ConversorTabela (Models.Request.ReciboDevolucaoRequest request)
        {
            Models.TbRecebimentoDevolucao tabela = new Models.TbRecebimentoDevolucao();

            tabela.IdDevolucao = request.devolucao;
            tabela.DsStatusLivro = request.descricao;
            tabela.DtRecebimentoLivro = request.data_recebido;

            return tabela;
        }

        public Models.Response.ReciboDevolucaoResponse ConversorResponse (Models.TbRecebimentoDevolucao tabela)
        {
            Models.Response.ReciboDevolucaoResponse response = new Models.Response.ReciboDevolucaoResponse();

            response.id = tabela.IdLivroDevolvido;
            response.devolucao = tabela.IdDevolucao;
            response.descricao = tabela.DsStatusLivro;
            response.data_recebido = tabela.DtRecebimentoLivro;

            return response;
        }
    }
}