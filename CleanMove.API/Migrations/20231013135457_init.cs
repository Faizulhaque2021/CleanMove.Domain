using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanMove.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movie_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rantal_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rantal_Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Rantals",
                columns: table => new
                {
                    RantalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RantalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RantalExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rantals", x => x.RantalId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RantalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Rantals_RantalId",
                        column: x => x.RantalId,
                        principalTable: "Rantals",
                        principalColumn: "RantalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRantals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RantalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRantals", x => new { x.RentalId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieRantals_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRantals_Rantals_RantalId",
                        column: x => x.RantalId,
                        principalTable: "Rantals",
                        principalColumn: "RantalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_RantalId",
                table: "Members",
                column: "RantalId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRantals_MovieId",
                table: "MovieRantals",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRantals_RantalId",
                table: "MovieRantals",
                column: "RantalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MovieRantals");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rantals");
        }
    }
}
