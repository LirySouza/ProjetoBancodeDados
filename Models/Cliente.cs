using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancodeDados.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Código do Cliente")]
        public int Id { get;set; }

        [Column("NomeCliente")]
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; } = string.Empty;
    }
}
