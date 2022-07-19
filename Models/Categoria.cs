using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_model.Models;


public class Categoria
{
    [Key]
    public int Id { get; set; }
    public string NomeCategoria { get; set; }

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    public Categoria(string nomeCategoria)
    {

        NomeCategoria = nomeCategoria;
 
    }
}


//public class PostCategories
///{
    //public Post Post { get; set; }
   // public List<Category> Categories { get; set; }
//}

