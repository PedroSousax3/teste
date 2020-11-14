namespace api.Utils.Conversor
{
    public class EstoqueConvert
    {
        public Models.TbEstoque ConversorTabela(Models.Request.EstoqueRequest request)
        {
            Models.TbEstoque tabela = new Models.TbEstoque();

            tabela.IdLivro = request.livro;
            tabela.NrQuantidade = request.qtd;
            tabela.DtAtualizacao = System.DateTime.Now;

            return tabela;
        }

        public Models.Response.EstoqueResponce ConversorResponse(Models.TbEstoque tabela)
        {
            if(tabela == null)
                return null;
                
            Models.Response.EstoqueResponce responce = new Models.Response.EstoqueResponce();

            responce.id = tabela.IdEstoque;
            responce.livro = tabela.IdLivro;
            responce.qtd = tabela.NrQuantidade;
            responce.atualizacao = tabela.DtAtualizacao;

            return responce;
        }
    }
}