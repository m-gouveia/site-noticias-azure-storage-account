using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public interface INoticiaRepository
    {
        void SalvarNoticia(NoticiaModel noticiaModel, string nomeArquivo);
    }
}
