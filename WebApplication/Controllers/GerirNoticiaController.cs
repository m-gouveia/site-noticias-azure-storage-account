using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication.Blob;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    public class GerirNoticiaController : Controller
    {
        private IBlobHandler _blobHandler;
        private INoticiaRepository _noticiaRepository;

        public GerirNoticiaController(IBlobHandler blobHandler, INoticiaRepository noticiaRepository)
        {
            _blobHandler = blobHandler;
            _noticiaRepository = noticiaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Salvar(NoticiaModel model)
        {
            try
            {
                string nomeArquivo = $"{Guid.NewGuid()}.{model.ArquivoImagem.FileName.Split(".")[1]}";

                _blobHandler.SaveToContainer(model, nomeArquivo);
                _noticiaRepository.SalvarNoticia(model, nomeArquivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
