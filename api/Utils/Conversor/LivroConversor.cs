using System;
using System.Linq;

namespace api.Utils.Conversor
{
    public class LivroConversor : Utils.Conversor.MedidasConversor
    {
        public Models.TbLivro Conversor(Models.Request.LivroRequest livro)
        {
            Models.TbLivro tabela = new Models.TbLivro();

            tabela.IdEditora = livro.editora;
            tabela.NmLivro = livro.nome;
            tabela.DsLivro = livro.descricao;
            tabela.DtLancamento = livro.lancamento;
            tabela.DsIdioma = livro.idioma;
            tabela.TpAcabamento = livro.encapamento;
            tabela.NrPaginas = livro.paginas;
            tabela.DsIsbn = livro.isbn;
            tabela.NrEdicao = livro.edicao;
            tabela.VlPrecoCompra = Convert.ToDecimal(livro.compra);
            tabela.VlPrecoVenda = Convert.ToDecimal(livro.venda);
            tabela.IdMedidaNavigation = Conversor(livro.medidas);
            return tabela;
        }

        public Models.Response.LivroResponse Conversor(Models.TbLivro tabela)
        {
            if(tabela == null)
                return null;
                
            Models.Response.LivroResponse livro = new Models.Response.LivroResponse();

            livro.id = tabela.IdLivro;
            livro.nome = tabela.NmLivro;
            livro.descricao = tabela.DsLivro;
            livro.lancamento = tabela.DtLancamento;
            livro.idioma = tabela.DsIdioma;
            livro.encapamento = tabela.TpAcabamento;
            livro.foto = tabela.DsCapa;
            livro.paginas = tabela.NrPaginas;
            livro.isbn = tabela.DsIsbn;
            livro.edicao = tabela.NrEdicao;
            livro.compra = Convert.ToDouble(tabela.VlPrecoCompra);
            livro.venda = Convert.ToDouble(tabela.VlPrecoVenda);

            MedidasConversor MedidaConvert = new MedidasConversor();
            if(tabela.IdMedidaNavigation == null)
                livro.medida = null;
            else
                livro.medida = MedidaConvert.Conversor(tabela.IdMedidaNavigation);
            EditoraConversor EditoraConvert = new EditoraConversor();
            if(tabela.IdMedidaNavigation == null)
                livro.editora = null;
            else
                livro.editora = EditoraConvert.Conversor(tabela.IdEditoraNavigation);

            return livro;
        }

        public Models.Response.LivroCompleto ConversorCompleto(Models.TbLivro tabela)
        {
            Models.Response.LivroCompleto response = new Models.Response.LivroCompleto();

            EditoraConversor EditoraConvert = new EditoraConversor();
            AutorConversor AutorConvert = new AutorConversor();
            GeneroConversor GeneroConvert = new GeneroConversor();
            EstoqueConvert EstoqueConversor = new EstoqueConvert();
            
            response.idlivro = tabela.IdLivro;
            response.livro = this.Conversor(tabela);
            
            if(tabela.IdEditoraNavigation == null)
                response.livro.editora = null;
            else     
                response.livro.editora = EditoraConvert.Conversor(tabela.IdEditoraNavigation);
            if(tabela.TbLivroAutor == null)
                response.autores = null;
            else
                response.autores = tabela.TbLivroAutor.Select(x => AutorConvert.ConversorResponse(x.IdAutorNavigation)).ToList();
            if(tabela.TbLivroGenero == null)
                response.generos = null;
            else
                response.generos = tabela.TbLivroGenero.Select(x => GeneroConvert.ParaResponseListarGenero(x.IdGeneroNavigation)).ToList();
            if(tabela.TbEstoque == null)
                response.estoque_livro = null;
            else 
                response.estoque_livro = tabela.TbEstoque.Select(x => EstoqueConversor.ConversorResponse(x)).FirstOrDefault(y => y.id >= 1);

            return response;
        }
    }
}