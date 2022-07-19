using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using la_mia_pizzeria_model.Database;
using la_mia_pizzeria_model.Models;
using Microsoft.IdentityModel.Tokens;

namespace la_mia_pizzeria_model.Controllers
{
    public class PizzaController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza listPizza)
        {
            // using (PizzaContext db = new PizzaContext())
            //{
            if (!ModelState.IsValid)
            {
                return View("Create", listPizza);
            }
            using (PizzaContext db = new PizzaContext())
            {
                db.Pizzas.Add(listPizza);
                db.SaveChanges();

            }


            return RedirectToAction("Index");
            // }
        }

        public ActionResult Index()
        {


            using (PizzaContext db = new PizzaContext())
            {
                //create
                //Pizza nuovaPizza = new Pizza();
                //nuovaPizza.NomePizza = "Margherita";
                //nuovaPizza.Descrizione ="La margherita più buona della città";
                //nuovaPizza.PathImage = "Margherita";
                //nuovaPizza.Prezzo = 5.45f;

                //Pizza nuovaPizza = new Pizza("Margherita", "La margherita più buona della città", "pathimage", 5.45f);
                //Pizza nuovaPizza1 = new Pizza("Capricciosa", "Super pizza Capricciosa", "pathimage", 6.5f);
                // Pizza nuovaPizza2 = new Pizza("Tonno e Cipolla", "Rossi", "pathimage", 6.5f);

                //db.Add(nuovaPizza);
                //db.Add(nuovaPizza1);
                //db.Add(nuovaPizza2);

                // db.SaveChanges();

                //Console.WriteLine("recupero lista pizze");
                List<Pizza> listPizza = db.Pizzas.OrderBy(pizza => pizza.Id).ToList<Pizza>();
                if (listPizza == null)
                {
                    return NotFound("Pizze non presenti");
                }
                return View(listPizza);
            }
        }


        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound("Pizza non trovata");
                }
                else
                {
                    //db.Entry(pizza).Collection("IngredienteList").Load();
                    return View("Details", pizza);
                }
            }
        }

        //POST:HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", pizza);
            }
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaEdit = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaEdit != null)
                {
                    pizzaEdit.NomePizza = pizza.NomePizza;
                    pizzaEdit.Descrizione = pizza.Descrizione;
                    pizzaEdit.PathImage = pizza.PathImage;
                    pizzaEdit.Prezzo = pizza.Prezzo;

                    db.SaveChanges();
                }
                else
                {
                    return NotFound(View("Error"));
                }
            }
            return RedirectToAction("Index");
        }

        // GET: HomeController1/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaEdit = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaEdit == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(pizzaEdit);
                }
            }
            return View();
        }

        // GET: HomeController1/Delete/5
      

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaDelete = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDelete == null)
                {

                    return NotFound();
                }
                else
                {
                    db.Pizzas.Remove(pizzaDelete);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
