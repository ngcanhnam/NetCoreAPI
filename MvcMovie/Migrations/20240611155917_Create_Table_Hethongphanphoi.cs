using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Hethongphanphoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hethongphaphoi ",
                table: "hethongphaphoi ");

            migrationBuilder.RenameTable(
                name: "hethongphaphoi ",
                newName: "Hethongphanphoi");

            migrationBuilder.RenameColumn(
                name: "TenHTPP",
                table: "Hethongphanphoi",
                newName: "HTPPName");

            migrationBuilder.RenameColumn(
                name: "MaHTPP",
                table: "Hethongphanphoi",
                newName: "HTPPId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hethongphanphoi",
                table: "Hethongphanphoi",
                column: "HTPPId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hethongphanphoi",
                table: "Hethongphanphoi");

            migrationBuilder.RenameTable(
                name: "Hethongphanphoi",
                newName: "hethongphaphoi ");

            migrationBuilder.RenameColumn(
                name: "HTPPName",
                table: "hethongphaphoi ",
                newName: "TenHTPP");

            migrationBuilder.RenameColumn(
                name: "HTPPId",
                table: "hethongphaphoi ",
                newName: "MaHTPP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hethongphaphoi ",
                table: "hethongphaphoi ",
                column: "MaHTPP");
        }
    }
}
