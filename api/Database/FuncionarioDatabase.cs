using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
namespace api.Database
{
    public class FuncionarioDatabase
    {
        Models.db_next_gen_booksContext context = new Models.db_next_gen_booksContext();

        public async Task<Models.TbFuncionario> CadastrarFuncionario(Models.TbFuncionario tabela)
        {
            await context.TbFuncionario.AddAsync(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }

        public Task<List<Models.TbFuncionario>> ListarFuncionarios()
        {
            return context.TbFuncionario.ToListAsync();
        }
        public Task<Models.TbFuncionario> ConsultarPorId(int id)
        {
            return context.TbFuncionario.FirstOrDefaultAsync(x => x.IdFuncionario == id);
        }

        public async Task<Models.TbFuncionario> AlterarFuncionario(int id,Models.TbFuncionario novaTabela)
        {
            Models.TbFuncionario tabela = await ConsultarPorId(id);
            tabela.DsCargo = novaTabela.DsCargo;
            tabela.DsCarteiraTrabalho = novaTabela.DsCarteiraTrabalho;
            tabela.DsCep = novaTabela.DsCep;
            tabela.DsComplemento = novaTabela.DsComplemento;
            tabela.DsCpf = novaTabela.DsCpf;
            tabela.DsEmail = novaTabela.DsEmail;
            tabela.DsEndereco = novaTabela.DsEndereco;
            tabela.DtAdmissao = novaTabela.DtAdmissao;
            tabela.DtNascimento = novaTabela.DtNascimento;
            tabela.IdLogin = novaTabela.IdLogin;
            tabela.NmFuncionario = novaTabela.NmFuncionario;
            tabela.NrResidencial = novaTabela.NrResidencial;
            await context.SaveChangesAsync();
            return tabela;
        }

        public async Task<Models.TbFuncionario> DeletarFuncionario(int id)
        {
            Models.TbFuncionario tabela = await ConsultarPorId(id);
            context.TbFuncionario.Remove(tabela);
            await context.SaveChangesAsync();
            return tabela;
        }
    }
}