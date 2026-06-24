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
            return RedirectToAction("Login", "Conta");
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
            return RedirectToAction("Index", "Inicial");
        }

        [HttpGet]
        public IActionResult Perfil()
        {
            var model = new PerfilViewModel
            {
                Nome = "Usuário Exemplo",
                Email = "usuario@email.com",
                Telefone = "(11) 99999-9999"
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Perfil(PerfilViewModel model)
        {
            ViewBag.Mensagem = "Dados salvos com sucesso!";

            return View(model);
        }

    }
}