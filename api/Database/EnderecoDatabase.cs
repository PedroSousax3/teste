using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class EnderecoDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();
        public async Task<Models.TbEndereco> InserirEnderecoDatabase(Models.TbEndereco endereco)
        {
            await db.TbEndereco.AddAsync(endereco);
            await db.SaveChangesAsync();

            return endereco;
        }

        public async Task<Models.TbEndereco> ConsultarEnderecoPorId(int idendereco)
        {
            var endereco = await db.TbEndereco.FirstOrDefaultAsync(x => x.IdEndereco == idendereco);
            return endereco;
        }

        public async Task<List<Models.TbEndereco>> ListarEnderecoClienteDatabase(int cliente)
        {
            List<Models.TbEndereco> enderecos = await db.TbEndereco
                                                        .Where(x => x.IdCliente == cliente)
                                                        .ToListAsync();
            return enderecos;
        }

        public async Task<Models.TbEndereco> AlterarEndereco(int idendereco, Models.TbEndereco novo)
        {
            var atual = await this.ConsultarEnderecoPorId(idendereco);
            
            atual.NmEndereco = novo.NmEndereco;
            atual.DsEndereco = novo.DsEndereco;
            atual.NrEndereco = novo.NrEndereco;
            atual.DsCep = novo.DsCep;
            atual.NmEstado = novo.NmEstado;
            atual.NmCidade = novo.NmCidade;
            
            await db.SaveChangesAsync();
            return atual;
        }

        public async Task<Models.TbEndereco> RemoverEnderecoPorId(int idendereco)
        {
            var endereco = await this.ConsultarEnderecoPorId(idendereco);
            db.TbEndereco.Remove(endereco);
            await db.SaveChangesAsync();
            return endereco;
        }
    }
}