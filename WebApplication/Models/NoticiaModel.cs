using Microsoft.AspNetCore.Http;

namespace WebApplication.Models
{
    public class NoticiaModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IFormFile ArquivoImagem { get; set; }
    }
}
