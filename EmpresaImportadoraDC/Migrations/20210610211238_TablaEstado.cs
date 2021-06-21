using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpresaImportadoraDC.Migrations
{
    public partial class TablaEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Paquete");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Paquete",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Paquete",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEstado = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_EstadoId",
                table: "Paquete",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paquete_Estado_EstadoId",
                table: "Paquete",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paquete_Estado_EstadoId",
                table: "Paquete");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Paquete_EstadoId",
                table: "Paquete");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Paquete");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Paquete",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Paquete",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}
