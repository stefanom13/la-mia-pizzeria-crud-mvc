﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using la_mia_pizzeria_model.Database;

#nullable disable

namespace la_mia_pizzeria_model.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20220719155522_CreateCategorie")]
    partial class CreateCategorie
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Ingredienti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomeIngrediente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredienti");
                });

            modelBuilder.Entity("IngredientiPizza", b =>
                {
                    b.Property<int>("IngredientiPIzzaId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaIngredientiId")
                        .HasColumnType("int");

                    b.HasKey("IngredientiPIzzaId", "PizzaIngredientiId");

                    b.HasIndex("PizzaIngredientiId");

                    b.ToTable("IngredientiPizza");
                });

            modelBuilder.Entity("Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePizza")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prezzo")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("NomePizza")
                        .IsUnique();

                    b.ToTable("pizze");
                });

            modelBuilder.Entity("IngredientiPizza", b =>
                {
                    b.HasOne("Pizza", null)
                        .WithMany()
                        .HasForeignKey("IngredientiPIzzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ingredienti", null)
                        .WithMany()
                        .HasForeignKey("PizzaIngredientiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza", b =>
                {
                    b.HasOne("Categoria", "Categorie")
                        .WithMany("Pizza")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("Categoria", b =>
                {
                    b.Navigation("Pizza");
                });
#pragma warning restore 612, 618
        }
    }
}
