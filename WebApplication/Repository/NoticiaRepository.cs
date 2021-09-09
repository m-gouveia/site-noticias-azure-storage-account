using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly IConfiguration _configuration;

        public NoticiaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SalvarNoticia(NoticiaModel noticiaModel, string nomeArquivo)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("NoticiaDatabase")))
            {
                connection.Open();
                string query = "INSERT Noticia VALUES (@titulo, @descricao, @imagem)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@titulo", noticiaModel.Titulo));
                    command.Parameters.Add(new SqlParameter("@descricao", noticiaModel.Descricao));
                    command.Parameters.Add(new SqlParameter("@imagem", nomeArquivo));
                    command.ExecuteScalar();
                }
            }
        }

    }
}
