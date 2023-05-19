using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas = db.Pizzas.ToList<Pizza>();
                return View("Index", pizzas);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza newPizza = new Pizza();
                return View("Create", newPizza);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizzas.Add(newPizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {
                    return View("Update", pizzaToModify);
                }
                else
                {

                    return NotFound("Articolo da modifcare inesistente!");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza modifiedPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifiedPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {

                    pizzaToModify.Name = modifiedPizza.Name;
                    pizzaToModify.Description = modifiedPizza.Description;
                    pizzaToModify.Image = modifiedPizza.Image;
                    pizzaToModify.Price = modifiedPizza.Price;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("L'articolo da modificare non esiste!");
                }
            }

        }

    }

}
