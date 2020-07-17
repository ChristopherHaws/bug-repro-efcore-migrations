using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMigrationUpdateData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestEntities",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    TimeZone = table.Column<string>(nullable: false, defaultValueSql: "('UTC')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntities", x => x.Code)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.InsertData(
                table: "TestEntities",
                columns: new[] { "Code", "TimeZone" },
                values: new object[] { "code-1", "Eastern Standard Time" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestEntities");
        }
    }
}
