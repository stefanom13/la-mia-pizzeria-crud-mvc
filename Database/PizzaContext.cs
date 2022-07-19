using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using la_mia_pizzeria_model.Models;

namespace la_mia_pizzeria_model.Database
{

    public class PizzaContext : DbContext
    {
        

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredienti> Ingrediente { get; set; }
        public DbSet<Categoria> Categorie { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizza;Integrated Security=True");
        }


    }


}

