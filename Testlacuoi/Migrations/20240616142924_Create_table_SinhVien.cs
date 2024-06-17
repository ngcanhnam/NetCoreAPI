using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Testlacuoi.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_SinhVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSinhVien = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Hovaten = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MaLop = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSinhVien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVien");
        }
    }
}
