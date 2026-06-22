using System;
using System.ComponentModel.DataAnnotations;

namespace Compraí___Listas_compartilhadas.Models
{


    public class ListaArquivadaViewModel
    {
        public int Id { get; set; }

        public string NomeLista { get; set; }

        public DateTime? DataConclusao { get; set; }

        // Vem do Rateio.total_compra
        public decimal TotalCompra { get; set; }

        // Vem do Rateio.gasto_participante (média por pessoa)
        public decimal Contribuicao { get; set; }
    }
}