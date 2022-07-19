using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_model.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientiPizza_Pizzas_IngredientiPIzzaId",
                table: "IngredientiPizza");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.CreateTable(
                name: "pizze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePizza = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizze", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pizze_NomePizza",
                table: "pizze",
                column: "NomePizza",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientiPizza_pizze_IngredientiPIzzaId",
                table: "IngredientiPizza",
                column: "IngredientiPIzzaId",
                principalTable: "pizze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientiPizza_pizze_IngredientiPIzzaId",
                table: "IngredientiPizza");

            migrationBuilder.DropTable(
                name: "pizze");

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePizza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientiPizza_Pizzas_IngredientiPIzzaId",
                table: "IngredientiPizza",
                column: "IngredientiPIzzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
