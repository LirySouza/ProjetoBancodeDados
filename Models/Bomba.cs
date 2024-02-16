using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancodeDados.Models
{
    [Table("Bomba")]
    public class Bomba
    {
        [Column("BombaId")]
        [Display(Name = "Código da Bomba")]
        public int Id { get; set; }

        [Column("NumeroBomba")]
        [Display(Name = "Número da Bomba")]
        public int NumeroBomba { get; set; }

    }
}
