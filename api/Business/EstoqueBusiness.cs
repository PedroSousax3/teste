using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Business
{
    public class EstoqueBusiness : Business.Validador.ValidadorPadrao
    {
        Database.EstoqueDatabase database = new Database.EstoqueDatabase();

        public async Task RetirarQuantidadeVendidaBusiness(List<Models.TbVendaLivro> tabela)
        {
            await database.RetirarQuantidadeVendida(tabela);
        }
        public async Task<Models.TbEstoque> InserirBusiness (Models.TbEstoque novo)
        {
            ValidarId(novo.IdLivro);
            if(novo.NrQuantidade < 0)
                throw new ArgumentException("Valor minimo para inserir no estoque é 0");
            novo.DtAtualizacao = DateTime.Now;

            Models.TbEstoque estoque = await database.InserirEstoque(novo);
            
            if(estoque.IdEstoque <= 0)
                throw new ArgumentException("Não foi possivel cadastrar este estoque.");
            return estoque;
        }

        public async Task<Models.TbEstoque> ConsultarBusiness (int idestoque)
        {
            ValidarId(idestoque);
            Models.TbEstoque estoque = await database.ConsultarEstoquePorId(idestoque);
            if(estoque.IdEstoque <= 0)
                throw new ArgumentException("Não foi possivel consultar o estoque deste livro.");
            return estoque;
        }

        public async Task<List<Models.TbEstoque>> ListarEstoqueLivroBusiness (int idlivro)
        {
            ValidarId(idlivro);
            List<Models.TbEstoque> estoque = await database.ListarEstoquePorLivro(idlivro);
            if(estoque == null)
                throw new ArgumentException("Não foi possivel consultar o estoquedeste livro");
            return estoque;
        }

        public async Task<Models.TbEstoque> AlterarBusiness(int idestoque, Models.TbEstoque novo)
        {
            ValidarId(novo.IdLivro);
            if(novo.NrQuantidade < 0)
                throw new ArgumentException("Valor minimo para inserir no estoque é 0");
            novo.DtAtualizacao = DateTime.Now;

            Models.TbEstoque estoque = await database.AlterarEstoquePorId(idestoque, novo);
            
            if(estoque.IdEstoque <= 0)
                throw new ArgumentException("Não foi possivel alterar este estoque.");
            return estoque;
        }

        public async Task<Models.TbEstoque> RemoverEstoquePorId(int idestoque)
        {
            ValidarId(idestoque);
            Models.TbEstoque estoque = await database.RemoverEstoquePorId(idestoque);
            if(estoque.IdEstoque <= 0)
                throw new ArgumentException("Não foi possivel remover este estoque.");
            return estoque;
        }
    }
}