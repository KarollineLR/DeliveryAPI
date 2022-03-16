using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryAPI.Models
{
    [Table("tbl_pedidos")]
    public class Pedidos
    {
        [Display(Name = "ID")]
        [Column("id")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Column("nome")]
        public string nome { get; set; }

        [Display(Name = "Valor")]
        [Column("valor")]
        public decimal valor { get; set; }

    }
}
