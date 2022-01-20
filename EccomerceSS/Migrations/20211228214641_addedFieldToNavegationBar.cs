using Microsoft.EntityFrameworkCore.Migrations;

namespace EccomerceSS.Migrations
{
    public partial class addedFieldToNavegationBar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rolRequiredToAcess",
                table: "navegationBars",
                type: "nvarchar(20)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rolRequiredToAcess",
                table: "navegationBars");
        }
    }
}
