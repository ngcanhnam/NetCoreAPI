using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanhNamtest.Migrations
{
    /// <inheritdoc />
    public partial class Creat_table_Lophoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lophoc",
                columns: table => new
                {
                    Malop = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tenlop = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lophoc", x => x.Malop);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lophoc");
        }
    }
}
