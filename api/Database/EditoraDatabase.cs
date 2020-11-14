using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Collections.Generic;
using System;

namespace api.Database
{
    public class EditoraDatabase
    {
        db_next_gen_booksContext db = new db_next_gen_booksContext();
        public async Task<TbEditora> InserirEditora(TbEditora editora)
        {
            await db.TbEditora.AddAsync(editora);
            await db.SaveChangesAsync();

            return editora;
        }

        public async Task<List<TbEditora>> ListarEditoras()
        {
            return await db.TbEditora.ToListAsync();
        }

        public async Task<TbEditora> ConsultarEditoraPorId(int id)
        {
            var editora = await db.TbEditora.FirstOrDefaultAsync(x => x.IdEditora == id);
            return editora;
        }

        public async Task<TbEditora> AlterarEditora(int id, Models.TbEditora atual)
        {
            var editora = await this.ConsultarEditoraPorId(id);
            
            if(!string.IsNullOrEmpty(atual.NmEditora))
                editora.NmEditora = atual.NmEditora;
            if(!string.IsNullOrEmpty(atual.DsSigla))
                editora.DsSigla = atual.DsSigla;
            if(atual.DtFundacao > DateTime.Now)
                editora.DtFundacao = atual.DtFundacao;
            if(!string.IsNullOrEmpty(atual.DsLogo))
                editora.DsLogo = atual.DsLogo;

            await db.SaveChangesAsync();
            return editora;
        }

        public async Task<TbEditora> RemoverEditora(int id)
        {
            var editora = await this.ConsultarEditoraPorId(id);
            db.TbEditora.Remove(editora);
            await db.SaveChangesAsync();

            return editora;
        }
    }
}