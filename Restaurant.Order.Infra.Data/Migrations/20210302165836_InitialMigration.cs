using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Order.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "restaurantorder");

            migrationBuilder.CreateTable(
                name: "Mornings",
                schema: "restaurantorder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mornings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nights",
                schema: "restaurantorder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "restaurantorder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodType = table.Column<int>(nullable: false),
                    DishTypes = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDenormalized",
                schema: "restaurantorder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: true),
                    Dishes = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDenormalized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDenormalized_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "restaurantorder",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDenormalized_OrderId",
                schema: "restaurantorder",
                table: "OrderDenormalized",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mornings",
                schema: "restaurantorder");

            migrationBuilder.DropTable(
                name: "Nights",
                schema: "restaurantorder");

            migrationBuilder.DropTable(
                name: "OrderDenormalized",
                schema: "restaurantorder");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "restaurantorder");
        }
    }
}
