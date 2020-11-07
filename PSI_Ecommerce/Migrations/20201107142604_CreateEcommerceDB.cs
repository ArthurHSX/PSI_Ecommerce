using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSI_Ecommerce.Migrations
{
    public partial class CreateEcommerceDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    IdAnuncio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID = table.Column<int>(nullable: true),
                    TituloAnuncio = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.IdAnuncio);
                    table.ForeignKey(
                        name: "FK_Anuncio_Usuario_ID",
                        column: x => x.ID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    TelefoneFixo = table.Column<string>(nullable: true),
                    TelefoneMovel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contato_Usuario_ID",
                        column: x => x.ID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Nota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_ID",
                        column: x => x.ID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Anuncio_ID",
                        column: x => x.ID,
                        principalTable: "Anuncio",
                        principalColumn: "IdAnuncio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ComentarioPaiID = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentario_Comentario_ComentarioPaiID",
                        column: x => x.ComentarioPaiID,
                        principalTable: "Comentario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_ID",
                        column: x => x.ID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Anuncio_ID",
                        column: x => x.ID,
                        principalTable: "Anuncio",
                        principalColumn: "IdAnuncio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imagem = table.Column<byte[]>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true),
                    AnuncioIdAnuncio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Foto_Anuncio_AnuncioIdAnuncio",
                        column: x => x.AnuncioIdAnuncio,
                        principalTable: "Anuncio",
                        principalColumn: "IdAnuncio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foto_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_ID",
                table: "Anuncio",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ComentarioPaiID",
                table: "Comentario",
                column: "ComentarioPaiID");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_AnuncioIdAnuncio",
                table: "Foto",
                column: "AnuncioIdAnuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_UsuarioID",
                table: "Foto",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
