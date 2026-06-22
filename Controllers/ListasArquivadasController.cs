using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Compraí___Listas_compartilhadas.Models;

namespace Compraí___Listas_compartilhadas.Controllers
{
    public class ListasArquivadasController : Controller
    {
        // GET: /ListasArquivadas
        public IActionResult Index()
        {
            // Quando o banco estiver conectado, isso vira uma consulta
            // ao DbContext
            List<ListaArquivadaViewModel> listasArquivadas = new List<ListaArquivadaViewModel>
            {
                new ListaArquivadaViewModel
                {
                    Id = 1,
                    NomeLista = "Lista 1",
                    DataConclusao = new DateTime(2026, 4, 7, 14, 30, 0),
                    TotalCompra = 300.00m,
                    Contribuicao = 30.00m
                },
                new ListaArquivadaViewModel
                {
                    Id = 2,
                    NomeLista = "Lista 2",
                    DataConclusao = new DateTime(2026, 2, 17, 16, 30, 0),
                    TotalCompra = 300.00m,
                    Contribuicao = 50.00m
                },
                new ListaArquivadaViewModel
                {
                    Id = 3,
                    NomeLista = "Lista 3",
                    DataConclusao = new DateTime(2026, 4, 10, 16, 30, 0),
                    TotalCompra = 300.00m,
                    Contribuicao = 100.00m
                }
            };

            // Ordenar por "mais recentes" primeiro
            listasArquivadas = listasArquivadas
                .OrderByDescending(l => l.DataConclusao)
                .ToList();

            // Passamos o nome "ListasArquivadas" explicitamente,
            // porque o arquivo da View se chama ListasArquivadas.cshtml
            // (e não Index.cshtml, que seria o padrão esperado)
            return View("ListasArquivadas", listasArquivadas);
        }
    }
}