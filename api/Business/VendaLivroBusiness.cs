using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Business
{
    public class VendaLivro : Business.Validador.ValidadorPadrao
    {
        Database.VendaLivroDatabase database = new Database.VendaLivroDatabase();

        public async Task AlterarDevolvido(int IdVendaLivro)
        {
            ValidarId(IdVendaLivro);
            await database.AlterarDevolvido(IdVendaLivro);
        }
        public async Task<Models.TbVendaLivro> CadastrarBusiness(Models.TbVendaLivro novo)
        {
            ValidarId(novo.IdLivro);
            ValidarId(novo.IdVenda);
            if(novo.NrLivros <= 0)
                throw new ArgumentException("Quantidade do livro " + novo.IdLivroNavigation.NmLivro + " é invalida");
            novo.VlVendaLivro = novo.IdLivroNavigation.VlPrecoVenda;
            if(novo.VlVendaLivro <= 0)
                throw new ArgumentException("Valor do livro " + novo.IdLivroNavigation.NmLivro + " é invalida");
            Models.TbVendaLivro vendalivro = await database.CadastrarVendaLivro(novo);
            if(vendalivro.IdVendaLivro <= 0)
                throw new ArgumentException("Não foi possivel Cadastrar esta venda livro");
            return novo;
        }

        public async Task<Models.TbVendaLivro> ConsultarVendaLivroPorId(int idvendalivro)
        {
            ValidarId(idvendalivro);
            Models.TbVendaLivro vendalivro = await database.ConsultarVendaLivroPorId(idvendalivro);
            
            if(vendalivro == null)
                throw new ArgumentException("Não foi possivel consultar estar a venda deste livro.");
            return vendalivro;
        }
        
        public async Task<List<Models.TbVendaLivro>> ConsultarVendaLivroPorIdVenda(int idVenda)
        {
            ValidarId(idVenda);
            List<Models.TbVendaLivro> vendalivro = await database.ConsultarVendaLivroPorIdVenda(idVenda);
            
            if(vendalivro == null)
                throw new ArgumentException("Não foi possivel consultar estar a venda deste livro.");
            return vendalivro;
        }

        public List<Models.TbVendaLivro> ConsultarVendaLivroPorIdLivroBusiness(int id)
        {
            ValidarId(id);
            List<Models.TbVendaLivro> vendalivro = database.ConsultarVendaLivroPorIdLivro(id);
            
            if(vendalivro == null)
                throw new ArgumentException("Não foi possivel consultar estar a venda deste livro.");
            return vendalivro;
        }
        public async Task<Models.TbVendaLivro> DeletarVendaLivro(int id)
        {
            ValidarId(id);
            Models.TbVendaLivro vendalivro = await database.DeletarVendaLivro(id);
            
            if(vendalivro == null)
                throw new ArgumentException("Não foi possivel deletar estar a venda deste livro.");
            return vendalivro;
        }
        
        public async Task<Models.TbVendaLivro> AlterarVendaLivroBusiness(int id, Models.TbVendaLivro novo)
        {
            ValidarId(novo.IdLivro);
            ValidarId(novo.IdVenda);
            if(novo.NrLivros <= 0)
                throw new ArgumentException("Quantidade do livro " + novo.IdLivroNavigation.NmLivro + " é invalida");
            novo.VlVendaLivro = novo.IdLivroNavigation.VlPrecoVenda;
            if(novo.VlVendaLivro <= 0)
                throw new ArgumentException("Valor do livro " + novo.IdLivroNavigation.NmLivro + " é invalida");
            Models.TbVendaLivro vendalivro = await database.AlterarVendaLivro(id, novo);
            if(vendalivro.IdVendaLivro <= 0)
                throw new ArgumentException("Não foi possivel Cadastrar esta venda livro");
            return novo;
        }
        public async Task<List<Models.TbVendaLivro>> ListarTop10Vendas()
        {
            return await database.ListarTop10Vendas();
        }
    }
}