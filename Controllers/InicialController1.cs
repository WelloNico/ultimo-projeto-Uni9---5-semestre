using Microsoft.AspNetCore.Mvc;
using Compraí____Listas_compartilhadas.Models;

namespace Compraí____Listas_compartilhadas.Controllers
{
    public class InicialController : Controller
    {
        // GET: /Inicial/Index/3  (o "3" é o listaId)
        public IActionResult Index(int listaId)
        {
            // Por enquanto, sem banco conectado, só repassamos o id pra View
            // saber qual lista está sendo exibida (útil pro campo escondido do modal).
            // Quando o banco estiver pronto, aqui vai a busca real:
            // var lista = _context.Listas.FirstOrDefault(l => l.Id_lista == listaId);
            ViewBag.ListaId = listaId;

            return View();
        }

        // POST: /Inicial/AdicionarItem
        [HttpPost]
        public IActionResult AdicionarItem(NovoItemViewModel novoItem)
        {
            // Por enquanto não temos banco conectado, então só simulamos o recebimento.
            // Quando o EF Core estiver configurado, aqui vai o salvamento real:
            // _context.Itens.Add(new Item {
            //     ListaId = novoItem.ListaId,
            //     Produto = novoItem.Produto,
            //     Marca = novoItem.Marca,
            //     Quantidade = novoItem.Quantidade,
            //     Preco = novoItem.Preco
            // });
            // _context.SaveChanges();

            // Depois de salvar, o padrão é redirecionar de volta pra mesma lista,
            // já atualizada com o item novo.
            return RedirectToAction("Index", new { listaId = novoItem.ListaId });
        }
    }
}