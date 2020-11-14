using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace api.Business
{
    public class GerenciadorFile
    {
        public string GerarNovoNome(string nome)
        {
            string novoNome = Guid.NewGuid().ToString();
            novoNome = novoNome + Path.GetExtension(nome);
            return novoNome;
        }

        public void SalvarFile(string nome, IFormFile foto)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);

            using (FileStream fs = new FileStream(caminhoFoto, FileMode.Create))
            {
                foto.CopyTo(fs);
            }
        }

        public byte[] LerFile(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            byte[] foto = File.ReadAllBytes(caminhoFoto);

            return foto;
        }

        public void RemoverFile(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            File.Delete(caminhoFoto);
        }

        public string GerarContentType(string nome)
        {
            string extensao = System.IO.Path.GetExtension(nome).Replace(".", "");
            string contentType = "image/" + extensao;
            return contentType;
        }
    }
}