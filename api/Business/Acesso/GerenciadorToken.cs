using System;

namespace api.Business.Acesso
{
    public class GerenciadorToken : Utils.Criptografia.AES
    {
        private string GerarKey (Models.TbLogin login) 
        {
            string key = "@x#IWq69FT" + login.IdLogin;
            
            return key;            
        }

        public string GerarToken (Models.TbLogin login, int idperfil) 
        {
            string key = this.GerarKey(login).PadRight(16, '#');;
            string valor = $"{idperfil}$|${login.NmUsuario}$|${login.IdLogin}$|$Next-Gen-Books";
            string token = Encrypt(key, valor);

            return token;
        }

        public string LerToken (Models.TbLogin login, string token)
        {
            string key = this.GerarKey(login).PadRight(16, '#');
            string msn = Decrypt(key, token);

            return msn;
        }
    }
}