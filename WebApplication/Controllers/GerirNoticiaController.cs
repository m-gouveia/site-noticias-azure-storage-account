using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GerirNoticiaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Salvar(NoticiaModel model)
        {

        }
    }
}
