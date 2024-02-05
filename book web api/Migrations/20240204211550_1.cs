using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_web_api.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackBook = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_members_UserId",
                        column: x => x.UserId,
                        principalTable: "members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShelfId",
                table: "Books",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_WriterId",
                table: "Books",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BookId",
                table: "Rents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Writers");
        }
    }
}
