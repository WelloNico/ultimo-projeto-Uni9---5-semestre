namespace Compraí____Listas_compartilhadas.Models
{
    public class CriarListaViewModel
    {

        public string? NomeLista { get; set; }
        public List<ProdutoViewModel>? Produtos { get; set; }

    }

    public class ProdutoViewModel
    {
        public string? Produto { get; set; }
        public string? Marca { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }


}
