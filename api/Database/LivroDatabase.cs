using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class LivroDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
        public async Task<Models.TbLivro> InserirDatabaseAsync (Models.TbLivro livro)
        {
            await db.TbLivro.AddAsync(livro);
            await db.SaveChangesAsync();

            return livro;
        }

        public async Task<List<Models.TbLivro>> LitarLivrosDatabase()
        {
            List<Models.TbLivro> livros = await db.TbLivro.Include(x => x.IdEditoraNavigation).Include(x => x.IdMedidaNavigation).ToListAsync();
            return livros;
        }

        public async Task<Models.TbLivro> ConsultarLivroPorId(int idlivro)
        {
            Models.TbLivro livro =
                    await db.TbLivro.Include(x => x.IdMedidaNavigation)
                                    .Include(x => x.IdEditoraNavigation)
                                    .Include(x => x.TbLivroAutor).ThenInclude(y => y.IdAutorNavigation)
                                    .Include(x => x.TbLivroGenero).ThenInclude(z => z.IdGeneroNavigation)
                                    .Include(x => x.TbFavoritos)
                                    .Include(x => x.TbEstoque)
                                    .FirstOrDefaultAsync(x => x.IdLivro == idlivro);

            return livro;
        }

        public async Task<List<Models.TbLivro>> ListarLivroCompleto()
        {
            return await db.TbLivro.Include(x => x.IdMedidaNavigation)
                                    .Include(x => x.IdEditoraNavigation)
                                    .Include(x => x.TbLivroAutor)
                                    .Include(x => x.TbLivroGenero)
                                    .Include(x => x.TbEstoque)
                                    .ToListAsync();
        }

        public async Task<List<Models.TbLivro>> ListarLivroCompleto(int inicio, int fim, string nome)
        {
            return await db.TbLivro.Include(x => x.IdMedidaNavigation)
                                    .Include(x => x.IdEditoraNavigation)
                                    .Include(x => x.TbLivroAutor)
                                    .Include(x => x.TbLivroGenero)
                                    .Include(x => x.TbEstoque)
                                    .Where(x => x.NmLivro.Contains(nome))
                                    .Skip(inicio)
                                    .Take(fim)
                                    .ToListAsync();
        }

        public int ContarLivrosDatabase()
        {
            return db.TbLivro.Count();
        }

        public async Task<List<Models.TbLivro>> ListarLivros(int atual) {
            return await db.TbLivro.Include(x => x.IdMedidaNavigation)
                                    .Include(x => x.IdEditoraNavigation)
                                    .Include(x => x.TbLivroAutor).ThenInclude(y => y.IdAutorNavigation)
                                    .Include(x => x.TbLivroGenero).ThenInclude(y => y.IdGeneroNavigation)
                                    .Include(x => x.TbEstoque)
                                    .Skip(atual)
                                    .Take(50)
                                    .ToListAsync();
        }

        public async Task<Models.TbLivro> ConsultarLivroPorIdUnico(int idlivro)
        {
            return await db.TbLivro.Include(x => x.IdMedidaNavigation).FirstOrDefaultAsync(x => x.IdLivro == idlivro);
        }

        /*public async Task<Models.TbLivro> ConsultarLivroCompleto (int idlivro) 
        {
            List<Models.TbLivro> livros = await db.TbLivro.Include(x => x.IdEditoraNavigation).Include(x => x.IdMedidaNavigation).ToListAsync();
        }*/

        public async Task<List<Models.TbLivro>> ListarLivrosFiltro(Models.Request.LivrosFiltrosRequest filtros)
        {
            List<Models.TbLivro> livros = await this.ListarLivroCompleto();
            
            if(string.IsNullOrEmpty(filtros.acabamento))
                livros = livros.Where(x => x.TpAcabamento.Contains(filtros.acabamento))
                                .ToList();
            if(string.IsNullOrEmpty(filtros.nome))
                livros = livros.Where(x => x.IdEditoraNavigation.NmEditora.Contains(filtros.nome) || 
                                            x.NmLivro.Contains(filtros.nome))
                                            .ToList();
            if(filtros.valor_maximo >= 0 || filtros.valor_minimo >= 0)
                livros = livros.Where(x => x.VlPrecoVenda >= Convert.ToDecimal(filtros.valor_minimo) && 
                                            x.VlPrecoVenda <= Convert.ToDecimal(filtros.valor_maximo))
                                            .ToList(); 
            if(filtros.data_publicacao != null)
                livros = livros.Where(x => x.DtLancamento == filtros.data_publicacao)
                                .ToList();
            
            return livros;
        }

        public async  Task<Models.TbLivro> AlterarLivroDatabase(int idlivro, Models.TbLivro livro)
        {
            Models.TbLivro atual = await this.ConsultarLivroPorId(idlivro);

            atual.NmLivro = livro.NmLivro;
            atual.NrEdicao = livro.NrEdicao;
            atual.NrPaginas = livro.NrPaginas;
            atual.DsIsbn = livro.DsIsbn;
            atual.DsIdioma = livro.DsIdioma;
            atual.DsLivro = livro.DsLivro;
            atual.DtLancamento = livro.DtLancamento;
            atual.VlPrecoCompra = livro.VlPrecoCompra;
            atual.VlPrecoVenda = livro.VlPrecoVenda;
            atual.DsCapa = livro.DsCapa;

            atual.IdMedidaNavigation.VlAltura = livro.IdMedidaNavigation.VlAltura;
            atual.IdMedidaNavigation.VlLargura = livro.IdMedidaNavigation.VlLargura;
            atual.IdMedidaNavigation.VlPeso = livro.IdMedidaNavigation.VlPeso;
            atual.IdMedidaNavigation.VlProfundidades = livro.IdMedidaNavigation.VlProfundidades;

            await db.SaveChangesAsync();
            return livro;
        }

        public async Task<Models.TbLivro> RemoverDatabase(int idlivro)
        {
            Models.TbLivro livro = await this.ConsultarLivroPorId(idlivro);
            
            if(livro == null)
                return null;

            db.TbLivro.Remove(livro);
            await db.SaveChangesAsync();

            return livro;
        }
    }
}