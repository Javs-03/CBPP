using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    IdActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescActividad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HorarioDisponible = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CuposDisponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Activida__5EAF86A4DD3D9F90", x => x.IdActividad);
                });

            migrationBuilder.CreateTable(
                name: "Cabina",
                columns: table => new
                {
                    IdCabina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescCabina = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CamasDisponibles = table.Column<int>(type: "int", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    PrecioNoche = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cabina__8BC666EC04EE6EDC", x => x.IdCabina);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescProducto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__098892108EA7CE27", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescRol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__2A49584CC90E41EF", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF9761DDADEF", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__Rol__72C60C4A",
                        column: x => x.Rol,
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    ConsecutivoError = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    CodigoError = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origen = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBITACORA", x => x.ConsecutivoError);
                    table.ForeignKey(
                        name: "FK_Bitacora_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    NumTelefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__D5946642FDCABD1F", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK__Cliente__Usuario__6EF57B66",
                        column: x => x.Usuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantDias = table.Column<int>(type: "int", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Cliente = table.Column<int>(type: "int", nullable: false),
                    Cabina = table.Column<int>(type: "int", nullable: false),
                    Actividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reserva__0E49C69D4C99A6A6", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK__Reserva__Activid__6FE99F9F",
                        column: x => x.Actividad,
                        principalTable: "Actividad",
                        principalColumn: "IdActividad");
                    table.ForeignKey(
                        name: "FK__Reserva__Cabina__70DDC3D8",
                        column: x => x.Cabina,
                        principalTable: "Cabina",
                        principalColumn: "IdCabina");
                    table.ForeignKey(
                        name: "FK__Reserva__Cliente__71D1E811",
                        column: x => x.Cliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_IdUsuario",
                table: "Bitacora",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Usuario",
                table: "Cliente",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Actividad",
                table: "Reserva",
                column: "Actividad");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Cabina",
                table: "Reserva",
                column: "Cabina");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Cliente",
                table: "Reserva",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Rol",
                table: "Usuario",
                column: "Rol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Cabina");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
