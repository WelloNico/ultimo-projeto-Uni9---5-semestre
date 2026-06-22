using Compraí____Listas_compartilhadas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Compraí____Listas_compartilhadas.Controllers
{
    public class CriarListaController : Controller
    {
        [HttpGet]
        public IActionResult Criar()
        {
            var model = new CriarListaViewModel
            {
                Produtos = new List<ProdutoViewModel>()
                {
                    new ProdutoViewModel()
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Criar(CriarListaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Aqui salva a lista e os produtos no banco

            return RedirectToAction("Index");
        }
    }
}