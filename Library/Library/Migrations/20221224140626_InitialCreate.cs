using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfPublication = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "DateOfPublication", "Title" },
                values: new object[,]
                {
                    { 1, "Dan Abnett", new DateTime(2006, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horus Rising" },
                    { 2, "Alex Stewart", new DateTime(2003, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "For the Emperor" },
                    { 3, "Shota Khubuluri", new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The First Heretic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
