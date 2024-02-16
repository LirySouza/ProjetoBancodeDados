using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancodeDados.Models
{
    [Table("Funcionarios")]
    public class Funcionarios
    {
        [Column("FuncionariosId")]
        [Display(Name = "Código dos Funcionários")]
        public int Id { get; set; }

        [Column("NomeFuncionario")]
        [Display(Name = "Nome do Funcionário")]
        public string NomeFuncionario { get; set; } = string.Empty;

        [Column("CargoFuncionario")]
        [Display(Name = "Cargo do Funcionário")]
        public string CargoFuncionario { get; set; } = string.Empty;

    }
}
