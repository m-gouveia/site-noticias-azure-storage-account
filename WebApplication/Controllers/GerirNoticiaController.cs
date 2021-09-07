using Microsoft.AspNetCore.Mvc;
using WebApplication.Blob;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GerirNoticiaController : Controller
    {
        private IBlobHandler _blobHandler;

        public GerirNoticiaController(IBlobHandler blobHandler)
        {
            _blobHandler = blobHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Salvar(NoticiaModel model)
        {
            _blobHandler.SaveToContainer(model);
        }
    }
}
