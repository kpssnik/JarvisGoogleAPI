using Microsoft.EntityFrameworkCore.Migrations;

namespace JarvisGoogleAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcNames", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "SystemName", "UserName" },
                values: new object[,]
                {
                    { 1, "process_start", "запусти" },
                    { 2, "process_kill", "закрой" },
                    { 3, "browser_find", "найди" },
                    { 4, "jarvis_shutdown", "умри" }
                });

            migrationBuilder.InsertData(
                table: "ProcNames",
                columns: new[] { "Id", "SystemName", "UserName" },
                values: new object[,]
                {
                    { 1, "calc", "калькулятор" },
                    { 2, "devenv", "студию" },
                    { 3, "opera", "браузер" },
                    { 4, "notepad", "блокнот" },
                    { 5, "mspaint", "рисование" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "ProcNames");
        }
    }
}
