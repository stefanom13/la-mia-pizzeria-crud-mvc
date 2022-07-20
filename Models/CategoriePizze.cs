using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Database;



public class CategoriePizze
{
    public Pizza Pizza { set; get; }
    public List<Categoria>? Categorie { get; set; }



}




