using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Business
{
    public class VendaBusiness : Business.Validador.ValidadorPadrao
    {
        Database.VendaDatabase database = new Database.VendaDatabase();
        public async Task<Models.TbVenda> InserirBusiness(Models.TbVenda novo)
        {
            ValidarId(novo.IdCliente);
            ValidarId(novo.IdEndereco);
            ValidarTexto(novo.DsNf, "nota fiscal");
            if(novo.TpPagamento.ToLower() == "débito")
                novo.NrParcela = 1;
            
            Models.TbVenda venda = await database.InserirVenda(novo);
            if(venda == null)
                throw new ArgumentException("Não foi possivel cadastrar essa venda.");
            return venda;
        }

        public async Task<List<Models.TbVenda>> ListarVendasClienteBusiness(int idcliente)
        {
            ValidarId(idcliente);
            List<Models.TbVenda> vendas = await database.ListarVendasPorCliente(idcliente);
            if(vendas ==  null)
                throw new ArgumentException("Não foi possivel consultar as vendas deste cliente.");
            return vendas;
        }

        public async Task<Models.TbVenda> ConsultarPorIdBusiness(int idvenda)
        {
            ValidarId(idvenda);
            Models.TbVenda venda = await database.ConsultarVendaPorId(idvenda);
            if(venda ==  null)
                throw new ArgumentException("Não foi ossivel consultar as vendas deste cliente.");
            return venda;
        }

        public async Task<Models.TbVenda> AlterarBusinesss(int idrecebimento, Models.TbVenda novo)
        {
            ValidarId(novo.IdCliente);
            ValidarId(novo.IdEndereco);
            ValidarTexto(novo.DsNf, "nota fiscal");
            if(novo.TpPagamento.ToLower() == "débito")
                novo.NrParcela = 1;

            Models.TbVenda venda = await database.AlterarVendaDatabase(idrecebimento, novo);
            if(venda == null)
                throw new ArgumentException("Não foi possivel cadastrar essa venda.");
            return venda;
        }

        public async Task<Models.TbVenda> RemovervendaPorId(int idvenda)
        {
            ValidarId(idvenda);
            Models.TbVenda venda = await this.RemovervendaPorId(idvenda);
            if(venda == null)
                throw new ArgumentException("Não foi possivel cadastrar essa venda.");
            return venda;
        }

        public async Task<List<Models.TbVenda>> ValidarListarVendaPorDia(DateTime dia)
        {
            return await database.ListarVendaPorDia(dia);
        }

        public async Task<List<Models.TbVenda>> ValidarListarPorMes(DateTime mesInicio,DateTime mesFim)
        {
            return await database.ListarPorMes(mesInicio,mesFim);
        }

        public async Task<List<Models.TbVenda>>  ListarTop10Clientes()
        {
            return await database.ListarTop10Clientes();
        }


    }
}