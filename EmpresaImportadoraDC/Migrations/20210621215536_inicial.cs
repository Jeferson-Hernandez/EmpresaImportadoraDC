using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpresaImportadoraDC.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCasillero = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DireccionEntrega = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

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

            migrationBuilder.CreateTable(
                name: "Mercancia",
                columns: table => new
                {
                    MercanciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMercancia = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercancia", x => x.MercanciaId);
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    TransportadoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.TransportadoraId);
                });

            migrationBuilder.CreateTable(
                name: "ValorLibra",
                columns: table => new
                {
                    ValorLibraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorLi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorLibra", x => x.ValorLibraId);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    PaqueteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoLibras = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    NoGuiaUSA = table.Column<int>(type: "int", nullable: false),
                    TransportadoraUSA = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MercanciaId = table.Column<int>(type: "int", nullable: false),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoGuiaCO = table.Column<int>(type: "int", nullable: false),
                    TransportadoraCO = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ValorTotal = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.PaqueteId);
                    table.ForeignKey(
                        name: "FK_Paquete_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquete_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquete_Mercancia_MercanciaId",
                        column: x => x.MercanciaId,
                        principalTable: "Mercancia",
                        principalColumn: "MercanciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "EstadoId", "TipoEstado" },
                values: new object[,]
                {
                    { 1, "En Bodega Miami" },
                    { 2, "En tránsito a Colombia" },
                    { 3, "En bodega Colombia" },
                    { 4, "En tránsito a dirección del cliente" },
                    { 5, "Entregado" }
                });

            migrationBuilder.InsertData(
                table: "Mercancia",
                columns: new[] { "MercanciaId", "TipoMercancia" },
                values: new object[,]
                {
                    { 1, "Frágil" },
                    { 2, "Pesadas" },
                    { 3, "Peligrosas" },
                    { 4, "Perecederas" }
                });

            migrationBuilder.InsertData(
                table: "ValorLibra",
                columns: new[] { "ValorLibraId", "ValorLi" },
                values: new object[] { 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_ClienteId",
                table: "Paquete",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_EstadoId",
                table: "Paquete",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_MercanciaId",
                table: "Paquete",
                column: "MercanciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "ValorLibra");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Mercancia");
        }
    }
}
