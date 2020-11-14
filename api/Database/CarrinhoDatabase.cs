using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class CarrinhoDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
        public async Task<Models.TbCarrinho> InserirCarrinhoDatabase (Models.TbCarrinho tabela)
        {
            await db.AddAsync(tabela);
            await db.SaveChangesAsync();

            return tabela;
        }
        public void RetirarDoCarrinho(int idCliente)
        {
            List<Models.TbCarrinho> tabela =  db.TbCarrinho.Where(x => x.IdCliente == idCliente).ToList();
            db.TbCarrinho.RemoveRange(tabela);
            db.SaveChangesAsync();
        }

        public async Task<Models.TbCarrinho> ConsultarCarrinhoPorId (int idcarrinho)
        {
            Models.TbCarrinho carrinho = await db.TbCarrinho.FirstOrDefaultAsync(x => x.IdCarrinho == idcarrinho);

            return carrinho;
        }

        public List<Models.TbCarrinho> ListarCarrinhoCliente (int idcliente)
        {
            List<Models.TbCarrinho> carrinhos = db.TbCarrinho.Include(x => x.IdLivroNavigation)
                                                                .Include(x => x.IdLivroNavigation.IdEditoraNavigation)
                                                                .Include(x => x.IdLivroNavigation.TbEstoque)
                                                                .Include(x => x.IdLivroNavigation.TbLivroAutor)
                                                                .ThenInclude(x => x.IdAutorNavigation)
                                                                .Where(x => x.IdCliente == idcliente)
                                                                .ToList();

            return carrinhos;
        }

        public async Task<Models.TbCarrinho> AlterarCarrinhoPorId(int idcarrinho, int novoqtd)
        {
            Models.TbCarrinho carrinho = await this.ConsultarCarrinhoPorId(idcarrinho);
        
            carrinho.NrLivro = novoqtd;

            await db.SaveChangesAsync();
            return carrinho;
        }

        public async Task<Models.TbCarrinho> RemoverCarrinhoPorId(int idcarrinho)
        {
            Models.TbCarrinho carrinho = await this.ConsultarCarrinhoPorId(idcarrinho);
            db.TbCarrinho.Remove(carrinho);
            await db.SaveChangesAsync();

            return carrinho;
        }
    }
}