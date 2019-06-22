using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_CRUD.Migrations
{
    public partial class SalaryRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Workers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Workers",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
