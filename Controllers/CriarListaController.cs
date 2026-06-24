//using Compraí____Listas_compartilhadas.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Compraí____Listas_compartilhadas.Controllers
//{
//    public class CriarListaController : Controller
//    {
//        [HttpGet]
//        public IActionResult Criar()
//        {
//            var model = new CriarListaViewModel
//            {
//                Produtos = new List<ProdutoViewModel>()
//                {
//                    new ProdutoViewModel()
//                }
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Criar(CriarListaViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            // Aqui salva a lista e os produtos no banco

//            return RedirectToAction("Index");
//        }
//    }
//}


using Compraí____Listas_compartilhadas.Models;
using Compraí____Listas_compartilhadas.Data; // 👈 IMPORTANTE: Para achar o seu banco de dados
using Microsoft.AspNetCore.Mvc;

namespace Compraí____Listas_compartilhadas.Controllers
{
    public class CriarListaController : Controller
    {
        private readonly CompraiDbContext _context; // 👈 Conexão com o banco

        // Construtor que recebe o contexto do banco de dados
        public CriarListaController(CompraiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            // Isso garante que a tela já comece com pelo menos 1 linha na tabela
            var model = new CriarListaViewModel
            {
                Produtos = new List<ProdutoViewModel>()
                {
                    new ProdutoViewModel { Quantidade = 1 } // Começa com quantidade 1 por padrão
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Criar(CriarListaViewModel model)
        {
            // Valida se o nome da lista foi preenchido
            if (!ModelState.IsValid || string.IsNullOrEmpty(model.NomeLista))
            {
                return View(model);
            }

            // 1. Criamos o objeto da Lista real para salvar na tabela "LISTA"
            var novaLista = new ListaBD
            {
                NomeLista = model.NomeLista,
                ChaveAcesso = new Random().Next(1000, 9999).ToString(), // Chave aleatória de 4 dígitos
                data_compra = DateTime.Now
            };

            // Salva a lista primeiro para o MySQL gerar o id_lista (Auto Increment)
            _context.Listas.Add(novaLista);
            _context.SaveChanges();

            // 2. Agora pegamos os produtos que vieram da tabela e salvamos na tabela "ITEM"
            if (model.Produtos != null && model.Produtos.Any())
            {
                foreach (var prodForm in model.Produtos)
                {
                    // Ignora se o usuário adicionou uma linha mas deixou o nome do produto vazio
                    if (string.IsNullOrEmpty(prodForm.Produto)) continue;

                    var novoItem = new ItemBD
                    {
                        IdLista = novaLista.IdLista, // 👈 Vincula com o ID gerado automaticamente acima!
                        Descricao = prodForm.Produto,
                        Marca = prodForm.Marca,
                        Quantidade = prodForm.Quantidade,
                        Preco = prodForm.Preco
                    };

                    _context.Itens.Add(novoItem);
                }

                // Salva todos os itens de uma vez só no banco
                _context.SaveChanges();
            }

            // Redireciona o usuário para a página Inicial (Index da InicialController) 
            // já passando o ID da lista que acabou de ser criada!
            return RedirectToAction("Index", "Inicial", new { listaId = novaLista.IdLista });
        }
    }
}