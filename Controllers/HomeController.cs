using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Chefs_N_Dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs_N_Dishes.Controllers
{
    public class HomeController : Controller
    {

        private Chefs_N_DishesContext db;
        public HomeController(Chefs_N_DishesContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> allChefs = db.Chefs
            .Include(Chef => Chef.CreatedDishes)
            .ToList();
            return View("Index", allChefs);
        }

        [HttpGet("/dishes")]
        public IActionResult Dishes()
        {
            List<Dish> allDishes = db.Dishes
            .Include(Chef => Chef.Creator)
            .ToList();
            return View("Dishes", allDishes);
        }

        [HttpGet("/add")]
        public IActionResult ViewAddChef()
        {
            return View("AddChef");
        }

        [HttpGet("/add/dish")]
        public IActionResult ViewAddDish()
        {
            List<Chef> chefs = db.Chefs.ToList();
            ViewBag.Chefs = chefs;
            return View("AddDish");
        }

        [HttpPost("/add/dish")]
        public IActionResult AddDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(newDish);
                db.SaveChanges();
                return RedirectToAction("Dishes");
            }
            List<Chef> chefs = db.Chefs.ToList();
            ViewBag.Chefs = chefs;
            return View("AddDish");
        }


        [HttpPost("/add/chef")]
        public IActionResult AddChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                int age = DateTime.Now.Year - newChef.Birthday.Year;

                if (newChef.Birthday > DateTime.Today)
                {
                    ModelState.AddModelError("Birthday", "Must be a past date");
                    return View("AddChef");
                }
                db.Chefs.Add(newChef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
