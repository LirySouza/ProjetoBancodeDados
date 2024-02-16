using Microsoft.EntityFrameworkCore;

namespace ProjetoBancodeDados.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto>options) : base(options)
        { 
            
        }
        public DbSet<Vendas> Vendas { get; set; }

        public DbSet<Compras> Compras { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Fornecedores> Fornecedores { get; set; }

        public DbSet<Funcionarios> Funcionarios { get; set; }

        public DbSet<Bomba> Bomba { get; set; }

        public DbSet<Combustivel> Combustivel { get; set; }

    }
}
