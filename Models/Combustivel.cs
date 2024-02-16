using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancodeDados.Models
{
    [Table("Combustivel")]
    public class Combustivel
    {
        [Column("CombustivelId")]
        [Display(Name= "Código do Combustivel")]
        public int Id { get; set; }

        [Column("NomeCombustivel")]
        [Display(Name = "Nome do Combustível")]
        public string NomeCombustivel { get;set; } = string.Empty;

        [Column("TipoCombustivel")]
        [Display(Name = "Tipo de Combustível")]
        public string TipoCombustivel { get; set;} = string.Empty;

        [Column("PrecoCombustivel")]
        [Display(Name = "Preço do Combustível")]
        public decimal PrecoCombustivel { get; set; }
    }
}
