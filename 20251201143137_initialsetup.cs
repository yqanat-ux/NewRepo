using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Favbook.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boatbuy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    rentername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RENTEDrname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    boattype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    renttime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boatbuy", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boatbuy");
        }
    }
}
