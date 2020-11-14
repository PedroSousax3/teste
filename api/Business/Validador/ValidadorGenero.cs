using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Business.Validador
{
    public class ValidadorGenero : Business.Validador.ValidadorPadrao
    {

        public void ValidarListaGenero(List<Models.TbGenero> tabela)
        {
            if(tabela.Count == 0)
              throw new ArgumentException("Ainda não há registros");
        }
        public void ValidaGenero(bool jaexiste,Models.TbGenero tabela)
        {
            ValidarTexto(tabela.NmGenero,"De Nome do Genero");
            ValidarTexto(tabela.DsGenero, "De Descrição do genero");
            VerificarSeGeneroExiste(jaexiste);
        }
        public void ValidarIdGenero(int id)
        {
            ValidarId(id);
        }
        private void VerificarSeGeneroExiste(bool jaexiste)
        {
            if(jaexiste == true)
               throw new ArgumentException("Esse genero ja foi cadastrado");
        }

    }
}