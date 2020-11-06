using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSI_Ecommerce.Migrations
{
    public partial class CreateEcommerceBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Usuario",
                newName: "IdUsuario");

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    IdAnuncio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario =  table.Column<int>(nullable: true),
                    TituloAnuncio = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.IdAnuncio);
                    table.ForeignKey(
                        name: "FK_Anuncio_Usuario_UsuarioIdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    IdContato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TelefoneFixo = table.Column<string>(nullable: true),
                    TelefoneMovel = table.Column<string>(nullable: true),
                    IdUsuario =  table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_Contato_Usuario_UsuarioIdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAnuncio = table.Column<int>(nullable: true),
                    IdUsuario =  table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Nota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Anuncio_AnuncioIdAnuncio",
                        column: x => x.IdAnuncio,
                        principalTable: "Anuncio",
                        principalColumn: "IdAnuncio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_UsuarioIdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    IdComentario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario =  table.Column<int>(nullable: true),
                    IdAnuncio = table.Column<int>(nullable: true),
                    IdComentarioPai = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_Comentario_Anuncio_AnuncioIdAnuncio",
                        column: x => x.IdAnuncio,
                        principalTable: "Anuncio",
                        principalColumn: "IdAnuncio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Comentario_ComentarioPaiIdComentario",
                        column: x => x.IdComentarioPai,
                        principalTable: "Comentario",
                        principalColumn: "IdComentario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_UsuarioIdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    IdFoto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imagem = table.Column<byte[]>(nullable: true),
                    IdUsuario =  table.Column<int>(nullable: true),
                    IdAnuncio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.IdFoto);
                    table.ForeignKey(
                        name: "FK_Foto_Anuncio_AnuncioIdAnuncio",
                        column: x => x.IdAnuncio,
                        principalTable: "Anuncio",
                        principalColumn: "IdAnuncio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foto_Usuario_UsuarioIdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_UsuarioIdUsuario",
                table: "Anuncio",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_AnuncioIdAnuncio",
                table: "Avaliacao",
                column: "IdAnuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_UsuarioIdUsuario",
                table: "Avaliacao",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_AnuncioIdAnuncio",
                table: "Comentario",
                column: "IdAnuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ComentarioPaiIdComentario",
                table: "Comentario",
                column: "IdComentarioPai");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioIdUsuario",
                table: "Comentario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_UsuarioIdUsuario",
                table: "Contato",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_AnuncioIdAnuncio",
                table: "Foto",
                column: "IdAnuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_UsuarioIdUsuario",
                table: "Foto",
                column: "IdUsuario");
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

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Usuario",
                newName: "ID");
        }
    }
}
