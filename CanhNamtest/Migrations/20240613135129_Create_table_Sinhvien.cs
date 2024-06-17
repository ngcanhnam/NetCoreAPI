using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanhNamtest.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Sinhvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sinhvien",
                columns: table => new
                {
                    Masinhvien = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Hoten = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Malop = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinhvien", x => x.Masinhvien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sinhvien");
        }
    }
}
