﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Database;



public class Categoria
{
    [Key]
    public int Id { get; set; }
    public string NomeCategoria { get; set; }

    
    public List<Pizza> Pizza { get; set; }
    public Categoria()
    {

 
    }
}




