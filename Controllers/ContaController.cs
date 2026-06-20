using Microsoft.AspNetCore.Mvc;
using Compraí____Listas_compartilhadas.Models;

namespace Compraí____Listas_compartilhadas.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Regras pra salvar no banco <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< MEXER DEPOIS
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Regras pra autenticação (banco de dados) <<<<<<<<<<<<<<<<<<<<<<<<<<<< MEXER DEPOIS
            return RedirectToAction("Index", "Home");
        }

        
    }
}