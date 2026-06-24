using Microsoft.AspNetCore.Mvc;
using Compraí____Listas_compartilhadas.Data;
using Compraí____Listas_compartilhadas.Models;
using Microsoft.EntityFrameworkCore;

namespace Compraí____Listas_compartilhadas.Controllers
{
    public class InicialController : Controller


    {

        private readonly CompraiDbContext _context;

        public InicialController(CompraiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string? nomeLista, int? listaId)
        {
            ListaBD? listaAtual = null;

            // 1. Se veio o ID direto da tela de criação (o redirecionamento que acabou de acontecer)
            if (listaId.HasValue && listaId > 0)
            {
                listaAtual = _context.Listas.FirstOrDefault(l => l.IdLista == listaId);
            }
            // 2. Se o cliente buscou digitando o nome na barra de busca
            else if (!string.IsNullOrEmpty(nomeLista))
            {
                listaAtual = _context.Listas.FirstOrDefault(l => l.NomeLista.Contains(nomeLista));
            }
            // 3. Se a página abriu do zero (sem busca e sem ID novo), pega a última lista criada
            else
            {
                listaAtual = _context.Listas.OrderByDescending(l => l.IdLista).FirstOrDefault();
            }

            // Se encontramos uma lista válida no banco
            if (listaAtual != null)
            {
                // Enviamos o ID e o Nome corretos para a View
                ViewBag.ListaId = listaAtual.IdLista;
                ViewBag.NomeLista = listaAtual.NomeLista;

                // Busca apenas os itens que pertencem a ESSA lista específica
                var itensDaLista = _context.Itens
                                           .Where(i => i.IdLista == listaAtual.IdLista)
                                           .Select(i => new InicialViewModel
                                           {
                                               Quantidade = i.Quantidade,
                                               Produto = i.Descricao,
                                               Marca = i.Marca,
                                               Preco = i.Preco ?? 0m
                                           })
                                           .ToList();

                return View(itensDaLista);
            }

            // Caso o banco esteja totalmente vazio
            ViewBag.ListaId = 0;
            ViewBag.NomeLista = "Nenhuma lista encontrada";
            return View(new List<InicialViewModel>());
        }

        [HttpPost]
        public IActionResult AdicionarItem(ItemBD item)
        {

            if (item.IdLista <= 0)
            {
                // Guarda a mensagem de aviso para exibir na tela
                TempData["AvisoErro"] = "Crie ou selecione uma lista primeiro antes de adicionar itens!";

                // Redireciona de volta para a Index
                return RedirectToAction("Index", new { listaId = item.IdLista });
            }

            _context.Itens.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index", new { listaId = item.IdLista });
        }

        [HttpPost]
        public IActionResult DeletarLista(int idLista)
        {
            if (idLista > 0)
            {
                // 1. Busca a lista no banco
                var lista = _context.Listas.FirstOrDefault(l => l.IdLista == idLista);

                if (lista != null)
                {
                    // 2. Busca e remove primeiro os itens dessa lista (para evitar erro de chave estrangeira)
                    var itens = _context.Itens.Where(i => i.IdLista == idLista).ToList();
                    if (itens.Any())
                    {
                        _context.Itens.RemoveRange(itens);
                    }

                    // 3. Remove a lista pai
                    _context.Listas.Remove(lista);

                    // 4. Salva as alterações no MySQL
                    _context.SaveChanges();
                }
            }

            // Redireciona para a Index limpa. O método Index que arrumamos antes vai 
            // automaticamente tentar buscar a última lista restante no banco!
            return RedirectToAction("Index");
        }


    }
}