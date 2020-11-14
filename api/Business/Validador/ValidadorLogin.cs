using System.Linq;
using System;

namespace api.Business.Validador
{
    public class ValidadorLogin
    {
        Business.Validador.ValidadorPadrao validador = new Business.Validador.ValidadorPadrao();
        public void ValidarCadastroLogin(bool jaexisteEmail,bool jaexiste,string senha)
        {
           validador.ValidarTexto(senha,"Senha");
           ValidarUsuario(jaexiste);
           ValidarUsuarioPorEmail(jaexisteEmail);
           ValidarQuantideDeCaracteresSenha(senha);
           ValidarCaracteresEspeciaisSenha(senha);
           ValidarNumerosSenha(senha);
        }
        public void ValidarId(int id)
        {
          validador.ValidarId(id);
        }

        public void ValidarConfirmarLogin(string usuario,string senha)
        {
           validador.ValidarTexto(usuario,"Usuario");
           validador.ValidarTexto(senha,"Senha");
        }
        private void ValidarUsuarioPorEmail(bool jaexiste)
        {
            if(jaexiste == true)
             throw new ArgumentException("Esse Email ja esta Cadastrado"); 
        }
        private void ValidarUsuario(bool jaexiste)
        {
           if(jaexiste == true)
             throw new ArgumentException("Nome de usuario indísponivel");
        }
        private void ValidarQuantideDeCaracteresSenha(string senha)
        {
            if(senha.Length < 8)
              throw new ArgumentException("Aumente a quantidade de caracteres para deixar sua senha mais segura");
        }
        
        private void ValidarCaracteresEspeciaisSenha(string senha)
        {
            int contador = 0;
            foreach(char caracter in senha)
            {
                if(caracter == '@' || caracter == '#' || caracter == '$' 
                                   || caracter == '&'|| caracter == '%'
                                                     || caracter == '!')
                  contador++;
            }
             if(contador < 2)
               throw new ArgumentException("Acrescente no minímo dois caracteres especiais para deixar sua senha segura");
        }
        private void ValidarNumerosSenha(string senha)
        {
            int contador = 0;
            foreach(char caracter in senha)
            {
                if(char.IsNumber(caracter))
                  contador++;
            }
            if(contador < 2)
               throw new ArgumentException("Acrescente no minímo dois numeros para deixar sua senha mais forte");
        }

        public void ValidarSenha (string senha)
        {
          this.ValidarQuantideDeCaracteresSenha(senha);
          this.ValidarNumerosSenha(senha);
          this.ValidarCaracteresEspeciaisSenha(senha);
        }
    }
}