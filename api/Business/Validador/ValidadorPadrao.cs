using System;
namespace api.Business.Validador
{
    public class ValidadorPadrao
    {
        public void ValidarTexto(string texto,string descricao)
        {
            if(string.IsNullOrEmpty(texto))
             throw new ArgumentException("O campo " + descricao + " é obrigatorio");
        }
        public void ValidarId(int id)
        {
             if(id <= 0)
              throw new ArgumentException("O campo Id não pode ser menor que ou igual a zero");
        }
        public void ValidarData(DateTime? data,string descricao)
        {
            if(data == new DateTime() || data == null)
              throw new ArgumentException("O Campo " + descricao + "é obrigatorio");
        }
    }
}