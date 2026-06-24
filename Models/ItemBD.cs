    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Compraí____Listas_compartilhadas.Models
    {

        [Table("ITEM")]
        public class ItemBD
        {
            [Key]
            [Column("id_item")]
            public int IdItem { get; set; }


            [Column("id_lista")]
            public int IdLista { get; set; }


            [Column("descricao")]
            public string Descricao { get; set; }


            [Column("quantidade")]
            public int Quantidade { get; set; }

            [Column("marca")]
            public string? Marca { get; set; }

            [Column("preco")]
            public decimal? Preco { get; set; }
        }
    }
