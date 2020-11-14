using System;
namespace api.Business.Validador
{
    public class ValidadorCarrinho : ValidadorPadrao
    {
        public void ValidarCarrinho(Models.TbCarrinho tabela)
        {
            if(tabela == null)
               throw new ArgumentException("Essa tabela esta vazia"); 
               
           ValidarId(tabela.IdCliente);
           ValidarId(tabela.IdLivro);
           ValidarData(tabela.DtAtualizacao,"Data de Atualização");
        }

    }
}