using System;
using System.Security.Cryptography;
using System.Text;

namespace api.Utils.Criptografia
{
    public class AES
    {
        private RijndaelManaged gerarRijndael() 
        {
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.Mode = CipherMode.CBC;
            rijndael.KeySize = 128;

            return rijndael;
        }
        
        private void ValidarChave(string chave)
        {
            if (
                string.IsNullOrEmpty(chave) && (
                    chave.Length >= 16 && chave.Length <= 32
                )
            )
                throw new ArgumentException("Chave Invalida.");
        }

        public string Criptografar(string chave, string mensagem)
        {
            ValidarChave(chave);
            
            RijndaelManaged rijndael = this.gerarRijndael();

            byte[] chaveBytes;
            byte[] criptografiaBytes;
            byte[] mensagemBytes;
            string criptografia;

            chaveBytes = Encoding.UTF8.GetBytes(chave);
            mensagemBytes = Encoding.UTF8.GetBytes(mensagem);

            // Realiza criptografia
            ICryptoTransform cryptor = rijndael.CreateEncryptor(chaveBytes, chaveBytes);
            criptografiaBytes = cryptor.TransformFinalBlock(mensagemBytes, 0, mensagemBytes.Length);
            cryptor.Dispose();

            // Transforma criptografia em string
            criptografia = Convert.ToBase64String(criptografiaBytes);
            return criptografia;
        }

        private string Descriptografar(string chave, string valor)
        {
            ValidarChave(chave);

            RijndaelManaged rijndael = this.gerarRijndael();

            byte[] chaveBytes;
            byte[] criptografiaBytes;
            byte[] mensagemBytes;
            string mensagem;

            // Transforma chave e mensagem em array de byts
            chaveBytes = Encoding.UTF8.GetBytes(chave);
            mensagemBytes = Convert.FromBase64String(valor);

            ICryptoTransform cryptor = rijndael.CreateDecryptor(chaveBytes, chaveBytes);
            criptografiaBytes = cryptor.TransformFinalBlock(mensagemBytes, 0, mensagemBytes.Length);
            cryptor.Dispose();

            mensagem = Encoding.UTF8.GetString(criptografiaBytes);
            return mensagem;
        }

        public string Encrypt(string chave, string valor)
        {
            try
            {
                return this.Criptografar(chave, valor);
            }
            catch (System.Exception ex) 
            {   
                throw new ArgumentException(ex.Message);
            }
        }

        public string Decrypt(string chave, string valor)
        {
            try 
            {
                return this.Descriptografar(chave, valor);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException("Token Invalido." + ex.Message);
            }
        }
    }
}