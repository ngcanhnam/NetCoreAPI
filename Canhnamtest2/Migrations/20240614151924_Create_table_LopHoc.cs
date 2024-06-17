using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Canhnamtest2.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_LopHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenLop = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSinhVien = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MaLop = table.Column<int>(type: "INTEGER", nullable: true),
                    LopHocMaLop = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSinhVien);
                    table.ForeignKey(
                        name: "FK_SinhVien_LopHoc_LopHocMaLop",
                        column: x => x.LopHocMaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_LopHocMaLop",
                table: "SinhVien",
                column: "LopHocMaLop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "LopHoc");
        }
    }
}
