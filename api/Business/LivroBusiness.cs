using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Business
{
    public class LivroBusiness : Business.Validador.ValidadorPadrao
    {
        Database.LivroDatabase database = new Database.LivroDatabase();
        MedidaBusiness FunctionMedida = new MedidaBusiness();
        public async Task<Models.TbLivro> InserirBusinesa(Models.TbLivro tabela)
        {            
            ValidarTexto(tabela.DsIdioma, "idioma");
            ValidarTexto(tabela.DsIsbn, "numero isbn");
            ValidarTexto(tabela.DsLivro, "resumo");
            ValidarTexto(tabela.NmLivro, "nome do livro");
            if(tabela.NrPaginas <= 0)
                throw new ArgumentException("Número de paginas não foi informado.");
            if(tabela.NrEdicao <= 0)
                throw new ArgumentException("Número da edição não foi informado.");
           if(tabela.VlPrecoCompra <= 0)
                throw new ArgumentException("Valor de compra do livro não é valido.");
            if(tabela.VlPrecoVenda <= 0)
                throw new ArgumentException("Valor de venda do livro não é valido.");
            if(tabela.DtLancamento > DateTime.Now)
                throw new ArgumentException("Ano de lancamento do livro é superior a data atual.");

            return await database.InserirDatabaseAsync(tabela);
        }

        public async Task<Models.TbLivro> AlterarBusiness(int idlivro, Models.TbLivro tabela)
        {            
            ValidarTexto(tabela.DsIdioma, "idioma");
            ValidarTexto(tabela.DsIsbn, "numero isbn");
            ValidarTexto(tabela.DsLivro, "resumo");
            ValidarTexto(tabela.NmLivro, "nome do livro");
            if(tabela.NrPaginas <= 0)
                throw new ArgumentException("Número de paginas não foi informado.");
            if(tabela.NrEdicao <= 0)
                throw new ArgumentException("Número da edição não foi informado.");
           if(tabela.VlPrecoCompra <= 0)
                throw new ArgumentException("Valor de compra do livro não é valido.");
            if(tabela.VlPrecoVenda <= 0)
                throw new ArgumentException("Valor de venda do livro não é valido.");
            if(tabela.DtLancamento > DateTime.Now)
                throw new ArgumentException("Ano de lancamento do livro é superior a data atual.");

            return await database.AlterarLivroDatabase(idlivro, tabela);
        }

        public async Task<Models.TbLivro> ConsultarLivroIdBusiness (int id) 
        {
            ValidarId(id);
            return await database.ConsultarLivroPorId(id);
        }

        public async Task<Models.TbLivro> ConsultarLivroCompletoBusiness (int id) 
        {
            ValidarId(id);
            return await database.ConsultarLivroPorIdUnico(id);
        }
        
        public int ContarLivrosBusiness()
        {
            return database.ContarLivrosDatabase();
        }

        public async Task<List<Models.TbLivro>> ListarLivroBusiness (int inicio, int fim, string nome) 
        {
            return await database.ListarLivroCompleto(inicio, fim, nome);
        }
    }
}