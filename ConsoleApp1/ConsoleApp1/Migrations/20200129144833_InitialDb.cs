using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AusschreibungSet",
                columns: table => new
                {
                    AusschreibungId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(nullable: true),
                    Einstellungsdatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AusschreibungSet", x => x.AusschreibungId);
                });

            migrationBuilder.CreateTable(
                name: "BewerberSet",
                columns: table => new
                {
                    BewerberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BewerberSet", x => x.BewerberId);
                });

            migrationBuilder.CreateTable(
                name: "AdresseSet",
                columns: table => new
                {
                    AdresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ort = table.Column<string>(nullable: true),
                    Strasse = table.Column<string>(nullable: true),
                    BewerberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresseSet", x => x.AdresseId);
                    table.ForeignKey(
                        name: "FK_AdresseSet_BewerberSet_BewerberId",
                        column: x => x.BewerberId,
                        principalTable: "BewerberSet",
                        principalColumn: "BewerberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AusschreibungBewerberSet",
                columns: table => new
                {
                    AusschreibungBewerberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BewerberId = table.Column<int>(nullable: false),
                    AusschreibungId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AusschreibungBewerberSet", x => x.AusschreibungBewerberId);
                    table.ForeignKey(
                        name: "FK_AusschreibungBewerberSet_AusschreibungSet_AusschreibungId",
                        column: x => x.AusschreibungId,
                        principalTable: "AusschreibungSet",
                        principalColumn: "AusschreibungId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AusschreibungBewerberSet_BewerberSet_BewerberId",
                        column: x => x.BewerberId,
                        principalTable: "BewerberSet",
                        principalColumn: "BewerberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdresseSet_BewerberId",
                table: "AdresseSet",
                column: "BewerberId");

            migrationBuilder.CreateIndex(
                name: "IX_AusschreibungBewerberSet_AusschreibungId",
                table: "AusschreibungBewerberSet",
                column: "AusschreibungId");

            migrationBuilder.CreateIndex(
                name: "IX_AusschreibungBewerberSet_BewerberId",
                table: "AusschreibungBewerberSet",
                column: "BewerberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresseSet");

            migrationBuilder.DropTable(
                name: "AusschreibungBewerberSet");

            migrationBuilder.DropTable(
                name: "AusschreibungSet");

            migrationBuilder.DropTable(
                name: "BewerberSet");
        }
    }
}
