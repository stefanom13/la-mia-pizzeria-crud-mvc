
using la_mia_pizzeria_model.Database;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
//using (PizzaContext db = new PizzaContext())
//{
    //create
  //  List<Ingredienti> PizzaIngredienti = db.Ingrediente.ToList<Ingredienti>();
  //  List<Pizza> IngredientiPIzza = db.Pizzas.ToList<Pizza>();

  //  IngredientiPIzza[0].SetIngredienti(PizzaIngredienti[0], PizzaIngredienti[2],PizzaIngredienti[5]);
  //  IngredientiPIzza[1].SetIngredienti(PizzaIngredienti[0], PizzaIngredienti[2], PizzaIngredienti[1]);
  //  IngredientiPIzza[2].SetIngredienti(PizzaIngredienti[4], PizzaIngredienti[3], PizzaIngredienti[3]);

  //    db.SaveChanges();


//}


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=Index}/{id?}");

app.Run();
