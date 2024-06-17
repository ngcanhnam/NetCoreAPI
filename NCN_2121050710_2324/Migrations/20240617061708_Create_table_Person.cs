using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NCN_2121050710_2324.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    HoTen = table.Column<string>(type: "TEXT", nullable: false),
                    MaSinhVien = table.Column<string>(type: "TEXT", nullable: false),
                    Tuoi = table.Column<int>(type: "INTEGER", nullable: false),
                    TenLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.HoTen);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
