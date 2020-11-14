using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace api.Database
{
    public class VendaDatabase
    {
        Models.db_next_gen_booksContext db = new Models.db_next_gen_booksContext();

        public async Task<Models.TbVenda> InserirVenda(Models.TbVenda tabela)
        {
            await db.TbVenda.AddAsync(tabela);
            await db.SaveChangesAsync();

            return tabela;
        }

        public async Task<List<Models.TbVenda>> ListarVendasPorCliente(int idcliente)
        {
            List<Models.TbVenda> vendas = await db.TbVenda.Include(x => x.IdEnderecoNavigation)
                                                            .Where(y => y.IdCliente == idcliente)
                                                            .OrderByDescending(z => z.DtVenda)
                                                            .ToListAsync();

            return vendas;
        }

        public async Task<Models.TbVenda> ConsultarVendaPorId(int idvenda)
        {
            Models.TbVenda venda = await db.TbVenda.FirstOrDefaultAsync(x => x.IdVenda == idvenda);

            return venda;
        }

        public async Task<Models.TbVenda> AlterarVendaDatabase(int idrecebimento, Models.TbVenda novo)
        {
            Models.TbVenda atual = await this.ConsultarVendaPorId(idrecebimento);

            atual.IdCliente = novo.IdCliente;
            atual.IdEndereco = novo.IdEndereco;
            atual.BtConfirmacaoEntrega = novo.BtConfirmacaoEntrega;
            atual.DsCodigoRastreio = novo.DsCodigoRastreio;
            atual.DsStatusPagamento = novo.DsStatusPagamento;
            atual.DtPrevistaEntrega = novo.DtPrevistaEntrega;
            atual.DtVenda = novo.DtVenda;
            atual.NrParcela = novo.NrParcela;
            atual.TpPagamento = novo.TpPagamento;
            atual.VlFrete = novo.VlFrete;

            await db.SaveChangesAsync();
            return atual;
        }

        public async Task<Models.TbVenda> RemovervendaPorId(int idvenda)
        {
            Models.TbVenda venda = await this.ConsultarVendaPorId(idvenda);
            db.TbVenda.Remove(venda);
            await db.SaveChangesAsync();

            return venda;
        }

        public async Task<List<Models.TbVenda>> ListarVendaPorDia(DateTime dia)
        {
            return await db.TbVenda.Where(x => x.DtVenda.Value.Day == dia.Day
                                          && x.DtVenda.Value.Month == dia.Month
                                          && x.DtVenda.Value.Year == dia.Year)
                                            .Include(x => x.IdClienteNavigation)
                                            .Include(x => x.IdEnderecoNavigation)
                                            .Include(x => x.TbVendaStatus)
                                            .Include(x => x.TbVendaLivro)
                                            .ThenInclude(x => x.IdLivroNavigation)
                                            .ToListAsync();
                                                     
        } 

        public async Task<List<Models.TbVenda>> ListarPorMes(DateTime mesInicio,DateTime mesFim)
        {
             List<Models.TbVenda> tabela = await  db.TbVenda
                                                    .Where(x => x.DtVenda.Value.Month >= mesInicio.Month 
                                                    && x.DtVenda.Value.Month <= mesFim.Month)
                                                    .Include(x =>x.TbVendaLivro)
                                                    .ToListAsync();
            return tabela;
        }

        public async Task<List<Models.TbVenda>> ListarTop10Clientes()
        {
            return await db.TbVenda.Include(x =>x.IdClienteNavigation)
                                    .Include(x => x.TbVendaLivro)
                                    .Include(x => x.IdEnderecoNavigation)
                                    .ToListAsync();
        }

   
    }
}