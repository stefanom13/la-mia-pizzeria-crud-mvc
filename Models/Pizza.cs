using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_model.Database;
using la_mia_pizzeria_model.Models;

[Table("pizze")]
[Index(nameof(NomePizza), IsUnique = true)]
public class Pizza
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomePizza { get; set; }
    public string Descrizione { get; set; }
    public string PathImage { get; set; }
    public float Prezzo { get; set; }
   // public string CategoryID { get; set; }

    public List<Ingredienti>? PizzaIngredienti { get; set; }
    public List<Categoria> Categorie { get; set; }
    public Pizza(string nomePizza, string descrizione, string pathImage, float prezzo)
    {

        NomePizza = nomePizza;
        Descrizione = descrizione;
        PathImage = pathImage;
        Prezzo = prezzo;
    }
    public Pizza()
    {
    }

    //internal void SetIngredienti(Ingredienti ingredienti1, Ingredienti ingredienti2, Ingredienti ingredienti3)
    //{
    //PizzaIngredienti.Add(ingredienti1);
    // PizzaIngredienti.Add(ingredienti2);
    //PizzaIngredienti.Add(ingredienti3);
    // }
}



