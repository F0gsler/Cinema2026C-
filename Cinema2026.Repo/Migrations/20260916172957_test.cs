using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema2026.Repo.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieHalls",
                columns: table => new
                {
                    MovieHallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatAmount = table.Column<int>(type: "int", nullable: false),
                    occupied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieHalls", x => x.MovieHallId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    MovieHallId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_MovieHalls_MovieHallId",
                        column: x => x.MovieHallId,
                        principalTable: "MovieHalls",
                        principalColumn: "MovieHallId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MovieHallId",
                table: "Persons",
                column: "MovieHallId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "MovieHalls");
        }
    }
}
