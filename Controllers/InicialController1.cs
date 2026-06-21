using Microsoft.AspNetCore.Mvc;
using Compraí____Listas_compartilhadas.Models;

namespace Compraí____Listas_compartilhadas.Controllers
{
    public class InicialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}