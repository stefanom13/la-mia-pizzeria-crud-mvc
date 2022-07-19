using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_model.Migrations
{
    public partial class CreateTableIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeIngrediente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientiPizza",
                columns: table => new
                {
                    IngredientiPIzzaId = table.Column<int>(type: "int", nullable: false),
                    PizzaIngredientiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientiPizza", x => new { x.IngredientiPIzzaId, x.PizzaIngredientiId });
                    table.ForeignKey(
                        name: "FK_IngredientiPizza_Ingredienti_PizzaIngredientiId",
                        column: x => x.PizzaIngredientiId,
                        principalTable: "Ingredienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientiPizza_Pizzas_IngredientiPIzzaId",
                        column: x => x.IngredientiPIzzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientiPizza_PizzaIngredientiId",
                table: "IngredientiPizza",
                column: "PizzaIngredientiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientiPizza");

            migrationBuilder.DropTable(
                name: "Ingredienti");
        }
    }
}
