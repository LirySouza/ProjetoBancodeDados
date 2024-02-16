using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancodeDados.Models
{
    [Table("Compras")]
    public class Compras
    {
        [Column("ComprasId")]
        [Display(Name = "Código das Compras")]
        public int Id { get; set; }

        [Column("ValorCompra")]
        [Display(Name = "Valor Total da Compra")]
        public decimal ValorCompra { get; set; }


        [ForeignKey("FornecedoresId")]

        public int FornecedoresId { get; set; }

        public Fornecedores? Fornecedores { get; set; }
    }
}
