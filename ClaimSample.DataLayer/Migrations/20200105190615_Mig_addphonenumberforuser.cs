using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaimSample.DataLayer.Migrations
{
    public partial class Mig_addphonenumberforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "users",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "users");
        }
    }
}
