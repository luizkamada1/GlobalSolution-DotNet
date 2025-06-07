using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace globalsolution.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abrigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CapacidadeTotal = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CapacidadeAtual = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Recursos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abrigos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    TipoUsuario = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosAjuda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Latitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Bairro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosAjuda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosAjuda_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoRelato = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Latitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Bairro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ImagemUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    VideoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosAbrigados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdAbrigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosAbrigados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosAbrigados_Abrigos_IdAbrigo",
                        column: x => x.IdAbrigo,
                        principalTable: "Abrigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosAbrigados_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Disponibilidade = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voluntarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdVoluntario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacoes_Voluntarios_IdVoluntario",
                        column: x => x.IdVoluntario,
                        principalTable: "Voluntarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdVoluntario",
                table: "Doacoes",
                column: "IdVoluntario");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosAjuda_IdUsuario",
                table: "PedidosAjuda",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Relatos_IdUsuario",
                table: "Relatos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosAbrigados_IdAbrigo",
                table: "UsuariosAbrigados",
                column: "IdAbrigo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosAbrigados_IdUsuario",
                table: "UsuariosAbrigados",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntarios_IdUsuario",
                table: "Voluntarios",
                column: "IdUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacoes");

            migrationBuilder.DropTable(
                name: "PedidosAjuda");

            migrationBuilder.DropTable(
                name: "Relatos");

            migrationBuilder.DropTable(
                name: "UsuariosAbrigados");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "Abrigos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
