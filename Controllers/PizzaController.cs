using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using la_mia_pizzeria_model.Database;
using la_mia_pizzeria_model.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_model.Controllers
{
    public class PizzaController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Categoria> categoria = db.Categorie.ToList();
                CategoriePizze model = new CategoriePizze();

                model.Categorie = categoria;
                model.Pizza = new Pizza();
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriePizze p)
        {
            using (PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
            {
                p.Categorie = db.Categorie.ToList();
                return View("Create", p);
            }
            
                db.Pizzas.Add(p.Pizza);
                db.SaveChanges();

            }


            return RedirectToAction("Index");
            // }
        }

        public ActionResult Index()
        {


            using (PizzaContext db = new PizzaContext())
            {
                IQueryable<Pizza> listPizza = db.Pizzas.Include(piz => piz.Categorie);
               // List<Pizza> listPizza = db.Pizzas.OrderBy(pizza => pizza.Id).ToList<Pizza>();
                if (listPizza == null)
                {
                    return NotFound("Pizze non presenti");
                }
                return View("Index", listPizza.ToList());
            }
        }


        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                //Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
                Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).Include(cat => cat.Categorie).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound("Pizza non trovata");
                }
                else
                {
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
