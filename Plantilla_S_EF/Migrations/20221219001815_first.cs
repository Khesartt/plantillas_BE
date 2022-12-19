using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plantilla_S_EF.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(120)", nullable: true),
                    population = table.Column<long>(type: "bigint", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Token = table.Column<string>(type: "varchar(200)", nullable: false),
                    disabled = table.Column<bool>(type: "bit", nullable: false),
                    pib = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(120)", nullable: true),
                    population = table.Column<long>(type: "bigint", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Token = table.Column<string>(type: "varchar(200)", nullable: false),
                    disabled = table.Column<bool>(type: "bit", nullable: false),
                    pib = table.Column<int>(type: "int", nullable: false),
                    id_country = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.id);
                    table.ForeignKey(
                        name: "FK_City_Country_id_country",
                        column: x => x.id_country,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_id_country",
                table: "City",
                column: "id_country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
