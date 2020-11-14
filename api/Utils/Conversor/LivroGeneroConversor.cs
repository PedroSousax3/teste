namespace api.Utils.Conversor
{
    public class LivroGeneroConversor
    {
        public Models.TbLivroGenero ConversorTabela(Models.Request.LivroGeneroRequest request)
        {
            Models.TbLivroGenero tabela = new Models.TbLivroGenero();

            tabela.IdLivro = request.livro;
            tabela.IdGenero = request.genero;

            return tabela;
        }

        public Models.Response.LivroGeneroResponse ConversorResponse(Models.TbLivroGenero tabela)
        {
            Models.Response.LivroGeneroResponse response = new Models.Response.LivroGeneroResponse();

            response.id = tabela.IdLivroGenero;
            response.livro = tabela.IdLivro;
            response.genero = tabela.IdGenero;

            return response;
        }
    }
}