using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryPesistentEF.Migrations
{
    /// <inheritdoc />
    public partial class XX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                schema: "library",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                schema: "library",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                schema: "library",
                newName: "Authors",
                newSchema: "library");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                schema: "library",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                schema: "library",
                table: "BookAuthor",
                column: "AuthorId",
                principalSchema: "library",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                schema: "library",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                schema: "library",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                schema: "library",
                newName: "Author",
                newSchema: "library");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                schema: "library",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                schema: "library",
                table: "BookAuthor",
                column: "AuthorId",
                principalSchema: "library",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
