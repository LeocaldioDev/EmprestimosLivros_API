using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bi = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    telefoneFixo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    autor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    editora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    anoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    livroId = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    dataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    entregue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Emprestimo_Livro_livroId",
                        column: x => x.livroId,
                        principalTable: "Livro",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_clienteId",
                table: "Emprestimo",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_livroId",
                table: "Emprestimo",
                column: "livroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
