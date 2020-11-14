using System;
namespace api.Business.Validador
{
    public class ValidadorVendaStatus:Validador.ValidadorPadrao
    {
        public void ValidarVendaStatus(Models.TbVendaStatus tabela)
        {
            ValidarTexto(tabela.DsVendaStatus,"Venda Status");
            if(tabela.DtAtualizacao < DateTime.Now)
             throw new ArgumentException("Essa data nao pode ser menor do que a data Atual");
             ValidarId(tabela.IdVenda);
        }
    }
}