using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Business
{
    public class FavoritosBusiness : Business.Validador.ValidadorPadrao
    {
        Database.FavoritosDatabase database = new Database.FavoritosDatabase();
        public async Task<Models.TbFavoritos> InserirBusiness(Models.TbFavoritos novo)
        {
            ValidarId(novo.IdLivro);
            ValidarId(novo.IdCliente);

            List<Models.TbFavoritos> tabela = await this.ListarfavoritosBusiness(novo.IdCliente);
            if(tabela.Any(x => x.IdLivro == novo.IdLivro))
                throw new ArgumentException("Item já adicionado a lista de favoritos, não é possivel adicionado novamente.");

            Models.TbFavoritos favoritos = await database.InserirFavoritos(novo);
            
            if(favoritos == null)
                throw new ArgumentException("Não foi possivel adicionar o livro aos favoritos.");
            return favoritos;
        }

        public async Task<List<Models.TbFavoritos>> ListarfavoritosBusiness (int idcliente)
        {
            ValidarId(idcliente);
            List<Models.TbFavoritos> favoritos = await database.ListarfavoritosPorCliente(idcliente);
            if(favoritos == null || favoritos.Count <= 0)
                new ArgumentException("Não foi possivel encontrar os livros da lista de favoritos deste cliente");
            return favoritos;
        }

        public async Task<Models.TbFavoritos> ConsultarFavoritosPorId(int idfavorito)
        {
            ValidarId(idfavorito);
            Models.TbFavoritos favorito = await database.ConsultarFavoritosPorId(idfavorito);
            if(favorito == null)
                new ArgumentException("Não foi possivel encontrar o livro na lista de favoritos");
            return favorito;
        }

        public async Task<Models.TbFavoritos> AlterarFavoritosPorId(int idfavorito, Models.TbFavoritos novo)
        {

            ValidarId(novo.IdCliente);
            ValidarId(novo.IdLivro);
            Models.TbFavoritos favorito = await this.AlterarFavoritosPorId(idfavorito, novo);
            if(favorito == null)
                throw new ArgumentException("Não foi possivel alterar este livro na lista de favoritos.");
            return favorito;
        }
    
        public async Task<Models.TbFavoritos> RemoverFavoritosPorId(int idfavorito)
        {
            ValidarId(idfavorito);
        
            Models.TbFavoritos favorito = await database.RemoverFavoritosPorId(idfavorito);
            if(favorito == null)
                throw new ArgumentException("Não foi possivel alterar este livro na lista de favoritos.");
            return favorito;
        }
    }
}