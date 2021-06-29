using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace castgroup.repositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    QtdAlunos = table.Column<int>(type: "integer", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Cursos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CategoriaId",
                table: "Cursos",
                column: "CategoriaId");

            /// Cadastra as categorias no banco
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Codigo", "Descricao" },
                values: new object[] { Guid.NewGuid(),  "1", "Comportamental" }
                );
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Codigo", "Descricao" },
                values: new object[] { Guid.NewGuid(), "2", "Programação" }
                );
            migrationBuilder.InsertData(
              table: "Categorias",
              columns: new[] { "CategoriaId", "Codigo", "Descricao" },
              values: new object[] { Guid.NewGuid(), "3", "Qualidade" }
              );
            migrationBuilder.InsertData(
              table: "Categorias",
              columns: new[] { "CategoriaId", "Codigo", "Descricao" },
              values: new object[] { Guid.NewGuid(), "4", "Processos" }
              );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
