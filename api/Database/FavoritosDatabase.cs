using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class FavoritosDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
        public async Task<Models.TbFavoritos> InserirFavoritos(Models.TbFavoritos tabela)
        {
            await db.TbFavoritos.AddAsync(tabela);
            await db.SaveChangesAsync();

            return tabela;
        }

        public async Task<List<Models.TbFavoritos>> ListarfavoritosPorCliente (int idcliente)
        {
            List<Models.TbFavoritos> favoritos = await db.TbFavoritos.Where(x => x.IdCliente == idcliente)
                                                                        .Include(x => x.IdLivroNavigation.TbEstoque)
                                                                        .Include(x => x.IdLivroNavigation.TbLivroAutor)
                                                                        .ThenInclude(x => x.IdAutorNavigation)
                                                                        .Include(x => x.IdLivroNavigation)
                                                                        .Include(x => x.IdLivroNavigation.TbLivroGenero)
                                                                        .ThenInclude(x => x.IdGeneroNavigation)
                                                                        .Include(x => x.IdLivroNavigation.IdEditoraNavigation)
                                                                        .ToListAsync();
            return favoritos;
        }

        public async Task<Models.TbFavoritos> ConsultarFavoritosPorId(int idfavorito)
        {
            Models.TbFavoritos favorito = await db.TbFavoritos.FirstOrDefaultAsync(x => x.IdFavoritos == idfavorito);

            return favorito;
        }

        public async Task<Models.TbFavoritos> AlterarFavoritosPorId(int idfavorito, Models.TbFavoritos novo)
        {
            Models.TbFavoritos favorito = await this.ConsultarFavoritosPorId(idfavorito);

            favorito.IdLivro = novo.IdLivro;
            favorito.IdCliente = novo.IdCliente;
            favorito.DtInclusao = novo.DtInclusao;

            await db.SaveChangesAsync();
            return favorito;
        }
    
        public async Task<Models.TbFavoritos> RemoverFavoritosPorId(int idfavorito)
        {
            Models.TbFavoritos favorito = await this.ConsultarFavoritosPorId(idfavorito);

            db.TbFavoritos.Remove(favorito);
            await db.SaveChangesAsync();
            return favorito;
        }
    }
}