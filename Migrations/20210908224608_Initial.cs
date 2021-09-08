using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace musiC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amigos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "artistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amigosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_amigos_amigosId",
                        column: x => x.amigosId,
                        principalTable: "amigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Integrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Integrantes_artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bibliotecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bibliotecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bibliotecas_usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "albuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artistaId = table.Column<int>(type: "int", nullable: true),
                    criadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BibliotecaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_albuns_artistas_artistaId",
                        column: x => x.artistaId,
                        principalTable: "artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_albuns_bibliotecas_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "bibliotecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: true),
                    criadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BibliotecaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playlists_bibliotecas_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "bibliotecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_playlists_usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "musicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artistaId = table.Column<int>(type: "int", nullable: true),
                    lancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    PlaylistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musicas_albuns_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "albuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_musicas_artistas_artistaId",
                        column: x => x.artistaId,
                        principalTable: "artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_musicas_playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_albuns_artistaId",
                table: "albuns",
                column: "artistaId");

            migrationBuilder.CreateIndex(
                name: "IX_albuns_BibliotecaId",
                table: "albuns",
                column: "BibliotecaId");

            migrationBuilder.CreateIndex(
                name: "IX_bibliotecas_usuarioId",
                table: "bibliotecas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Integrantes_ArtistaId",
                table: "Integrantes",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_musicas_AlbumId",
                table: "musicas",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_musicas_artistaId",
                table: "musicas",
                column: "artistaId");

            migrationBuilder.CreateIndex(
                name: "IX_musicas_PlaylistId",
                table: "musicas",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_BibliotecaId",
                table: "playlists",
                column: "BibliotecaId");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_usuarioId",
                table: "playlists",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_amigosId",
                table: "usuarios",
                column: "amigosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Integrantes");

            migrationBuilder.DropTable(
                name: "musicas");

            migrationBuilder.DropTable(
                name: "albuns");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DropTable(
                name: "artistas");

            migrationBuilder.DropTable(
                name: "bibliotecas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "amigos");
        }
    }
}
