using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_model.Models;

    [Table("Ingredienti")]
    public class Ingredienti
    {
        [Key]
        public int Id { get; set; }
        public string NomeIngrediente { get; set; }
        public List<Pizza> IngredientiPIzza { get; set; }

        public Ingredienti(string nomeIngrediente)
        {

            NomeIngrediente = nomeIngrediente;
        }
    }

