using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMigrationUpdateData.Migrations
{
    public partial class NoChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TestEntities",
                keyColumn: "Code",
                keyValue: "code-1",
                column: "TimeZone",
                value: "Eastern Standard Time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TestEntities",
                keyColumn: "Code",
                keyValue: "code-1",
                column: "TimeZone",
                value: "Eastern Standard Time");
        }
    }
}
