using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compraí____Listas_compartilhadas.Models
{


    [Table("LISTA")]
    public class ListaBD
    {
        [Key]
        [Column("id_lista")]
        public int IdLista { get; set; }

        [Column("nome_lista")]
        public string NomeLista { get; set; }

        [Column("chave_acesso")]
        public string ChaveAcesso { get; set; }

        //[Column("data_compra")]
        //public DateTime? DataCompra { get; set; }

        //[Column("id_lista")]
        //public string? Status { get; set; }

        [Column("dataFinalizacao")]
        public DateTime? data_compra { get; set; }
    }
}
