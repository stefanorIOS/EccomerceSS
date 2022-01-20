using Microsoft.EntityFrameworkCore.Migrations;

namespace EccomerceSS.Migrations
{
    public partial class addedNavegationBarEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "navegationBars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    actionMethod = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    controllerMethod = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navegationBars", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "navegationBars");
        }
    }
}
