using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBancodeDados.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bomba",
                columns: table => new
                {
                    BombaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroBomba = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bomba", x => x.BombaId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Combustivel",
                columns: table => new
                {
                    CombustivelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCombustivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoCombustivel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustivel", x => x.CombustivelId);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedoresId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionariosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionariosId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    ComprasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FornecedoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.ComprasId);
                    table.ForeignKey(
                        name: "FK_Compras_Fornecedores_FornecedoresId",
                        column: x => x.FornecedoresId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedoresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeLitros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BombaId = table.Column<int>(type: "int", nullable: false),
                    CombustivelId = table.Column<int>(type: "int", nullable: false),
                    FuncionariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendasId);
                    table.ForeignKey(
                        name: "FK_Vendas_Bomba_BombaId",
                        column: x => x.BombaId,
                        principalTable: "Bomba",
                        principalColumn: "BombaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Combustivel_CombustivelId",
                        column: x => x.CombustivelId,
                        principalTable: "Combustivel",
                        principalColumn: "CombustivelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Funcionarios_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionariosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FornecedoresId",
                table: "Compras",
                column: "FornecedoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_BombaId",
                table: "Vendas",
                column: "BombaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CombustivelId",
                table: "Vendas",
                column: "CombustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FuncionariosId",
                table: "Vendas",
                column: "FuncionariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Bomba");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Combustivel");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
