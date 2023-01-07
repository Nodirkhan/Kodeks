using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodeksReaderPostgre.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codexes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bolimlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<float>(type: "real", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    KodeksId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolimlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolimlar_Codexes_KodeksId",
                        column: x => x.KodeksId,
                        principalTable: "Codexes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<float>(type: "real", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    BolimId = table.Column<Guid>(type: "uuid", nullable: true),
                    KodeksId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Bolimlar_BolimId",
                        column: x => x.BolimId,
                        principalTable: "Bolimlar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chapters_Codexes_KodeksId",
                        column: x => x.KodeksId,
                        principalTable: "Codexes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moddalar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<float>(type: "real", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Descrition = table.Column<string>(type: "text", nullable: true),
                    BobId = table.Column<Guid>(type: "uuid", nullable: true),
                    KodeksId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moddalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moddalar_Chapters_BobId",
                        column: x => x.BobId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Moddalar_Codexes_KodeksId",
                        column: x => x.KodeksId,
                        principalTable: "Codexes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolimlar_KodeksId",
                table: "Bolimlar",
                column: "KodeksId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BolimId",
                table: "Chapters",
                column: "BolimId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_KodeksId",
                table: "Chapters",
                column: "KodeksId");

            migrationBuilder.CreateIndex(
                name: "IX_Moddalar_BobId",
                table: "Moddalar",
                column: "BobId");

            migrationBuilder.CreateIndex(
                name: "IX_Moddalar_KodeksId",
                table: "Moddalar",
                column: "KodeksId");

            migrationBuilder.CreateIndex(
                name: "IX_Moddalar_Number",
                table: "Moddalar",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moddalar");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Bolimlar");

            migrationBuilder.DropTable(
                name: "Codexes");
        }
    }
}
