using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancodeDados.Models
{
    [Table("Fornecedores")]
    public class Fornecedores
    {
        [Column("FornecedoresId")]
        [Display(Name = "Código dos Fornecedores")]
        public int Id { get; set;}

        [Column("NomeFornecedor")]
        [Display(Name = "Nome do Fornecedor")]
        public string NomeFornecedor { get; set; } = string.Empty;

        [Column("CnpjFornecedor")]
        [Display(Name = "Cnpj do Fornecedor")]
        public string CnpjFornecedor { get; set; } = string.Empty;
    }
}
