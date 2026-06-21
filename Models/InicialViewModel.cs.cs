using System.ComponentModel.DataAnnotations;

namespace Compraí____Listas_compartilhadas.Models
{
    public class InicialViewModel
    {
        public int Quantidade { get; set; }
        public string? Produto { get; set; }
        public string? Marca { get; set; }
        public decimal Preco { get; set; }


        //*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< AQUI VAI AS COLUNAS DO BANCO DA TABELA "VALORES"
        //public decimal TotalCompra { get; set; }
        //public decimal Contribuicao { get; set; }
    }
}