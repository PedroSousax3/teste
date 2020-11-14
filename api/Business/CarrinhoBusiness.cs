using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace api.Business
{
    public class CarrinhoBusiness : Validador.ValidadorCarrinho
    {
        Database.CarrinhoDatabase database = new Database.CarrinhoDatabase();
        public async Task<Models.TbCarrinho> ValidarInserirCarrinho(Models.TbCarrinho tabela)
        {
            ValidarCarrinho(tabela);
            return await database.InserirCarrinhoDatabase(tabela);
        }

        public void ValidarRetirarDoCarrinho(int idCliente)
        {
            database.RetirarDoCarrinho(idCliente);
        }
        public async Task<Models.TbCarrinho> ValidarConsultaPorId(int id)
        {
            ValidarId(id);
            return await database.ConsultarCarrinhoPorId(id);
        }

        public async Task<Models.TbCarrinho> ValidarAlteracaoCarrinho(int id, int novaqtd)
        {
            ValidarId(id);
            if (novaqtd <= 0)
                throw new ArgumentException("Quantidade invalida.");

            return await database.AlterarCarrinhoPorId(id, novaqtd);
        }

        public List<Models.TbCarrinho> ValidarListarCarrinhoCliente(int id)
        {
            ValidarId(id);
            return database.ListarCarrinhoCliente(id);
        }

        public async Task<Models.TbCarrinho> ValidarAlterarCarrinho(int id, int novaqtd)
        {
            ValidarId(id);
            return await database.AlterarCarrinhoPorId(id, novaqtd);
        }

        public async Task<Models.TbCarrinho> ValidarDeletarCarrinho(int id)
        {
            ValidarId(id);
            return await database.RemoverCarrinhoPorId(id);
        }
    }
}