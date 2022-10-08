using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeVending.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    ImageLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeIngridient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeId = table.Column<int>(nullable: false),
                    IngridientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeIngridient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeeIngridient_Ingridients_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Ingridients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeIngridient_Coffees_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "Id", "ImageLocation", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "~/img/latte_01.jpg", "Latte", 5f },
                    { 2, "~/img/macchiato_01.jpg", "Macchiato", 6f },
                    { 3, "~/img/espresso_01.jpg", "Esspresso", 4f },
                    { 4, "~/img/americano_01.jpg", "Americano", 7f },
                    { 5, "~/img/irish_01.jpg", "Irish", 10f }
                });

            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Sugar", 0f },
                    { 2, "Creamer", 2f },
                    { 3, "Caramelle", 3f },
                    { 4, "More milk", 4f },
                    { 5, "has a single dose of milk", 3f },
                    { 6, "one pack of sugar", 0f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeIngridient_CoffeeId",
                table: "CoffeeIngridient",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeIngridient_IngridientId",
                table: "CoffeeIngridient",
                column: "IngridientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeIngridient");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "Coffees");
        }
    }
}
