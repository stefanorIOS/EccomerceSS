using Microsoft.EntityFrameworkCore.Migrations;

namespace EccomerceSS.Migrations
{
    public partial class fixedNameRolRequiredToAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rolRequiredToAcess",
                table: "navegationBars",
                newName: "rolRequiredToAccess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rolRequiredToAccess",
                table: "navegationBars",
                newName: "rolRequiredToAcess");
        }
    }
}
