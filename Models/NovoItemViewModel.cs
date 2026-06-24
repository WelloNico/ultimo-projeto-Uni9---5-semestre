namespace Compraí____Listas_compartilhadas.Models
{
    // Representa os dados preenchidos no modal "Adicione um novo produto na lista"
    public class NovoItemViewModel
    {
        // Identifica a qual lista esse item pertence.
        // Vai junto como campo escondido (hidden) no formulário do modal.
        public int ListaId { get; set; }

        public string Descricao { get; set; }

        public string Marca { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }
    }
}
