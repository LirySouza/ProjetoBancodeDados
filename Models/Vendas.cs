using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ProjetoBancodeDados.Models
{
    [Table("Vendas")]
    public class Vendas
    {
        [Column("VendasId")]
        [Display( Name = "Código das Vendas")]
        public int Id { get; set; }

        [ForeignKey("ClienteId")]

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("QuantidadeLitros")]
        [Display( Name = "Quantidade de Litros Abastecido")]
        public decimal QuantidadeLitros { get;set; }

        [ForeignKey("BombaId")]

        public int BombaId { get; set; }

        public Bomba? Bomba { get; set; }


        [ForeignKey("CombustivelId")]

        public int CombustivelId { get; set; }

        public Combustivel? Combustivel { get; set; }


        [ForeignKey("FuncionariosId")]

        public int FuncionariosId { get; set; }

        public Funcionarios? Funcionarios { get; set; }


    }
}
