using Microsoft.EntityFrameworkCore.Migrations;

namespace Project10_ShoppingDataDumper.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobilePhoneData",
                columns: table => new
                {
                    DeviceNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhoneData", x => x.DeviceNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobilePhoneData");
        }
    }
}
