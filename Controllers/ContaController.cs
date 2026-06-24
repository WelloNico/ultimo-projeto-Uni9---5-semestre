using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Compraí____Listas_compartilhadas.Data;
using Compraí____Listas_compartilhadas.Models;


namespace Compraí____Listas_compartilhadas.Controllers
{
    public class ContaController : Controller

    {

        private readonly CompraiDbContext _context;

        public ContaController(CompraiDbContext context)
        {
            _context = context;
        }

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

            if (_context.Usuarios.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "já existe um usuario utilizando esse email. Cadstre outro ou faça login.");
                return View(model);
            }

            var usuario = new Usuario
            {
                NomeCompleto = model.NomeCompleto,
                Email = model.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha) //senha criptografada
            };



            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

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

            var usuario = _context.Usuarios
                //firstOrDefault significa = traga o primeiro registro que encotrar que corresponda a condição, caso não encontre nenhum registro que corresponda a condição, ele retorne null
            .FirstOrDefault(u => u.Email == model.Email); // É lambda, são apelidinhos. Igual consulta SQL

            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválidos.");
                return View(model);
            }

            return RedirectToAction("Index", "Inicial");
        }


        [HttpGet]
        public IActionResult Perfil()
        {
            var usuario = _context.Usuarios.FirstOrDefault();

            if (usuario == null)
                return RedirectToAction("Cadastro");

            var model = new PerfilViewModel
            {
                Nome = usuario.NomeCompleto,
                Email = usuario.Email,
                Senha = ""
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Perfil(PerfilViewModel model)
        {
            var usuario = _context.Usuarios.FirstOrDefault();

            if (usuario == null)
                return RedirectToAction("Cadastro");

            usuario.NomeCompleto = model.Nome;
            usuario.Email = model.Email;

            if (!string.IsNullOrWhiteSpace(model.Senha))
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha);
            }

            _context.SaveChanges();

            ViewBag.Mensagem = "Dados salvos com sucesso!";

            return View(model);
        }


    }
}