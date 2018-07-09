using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class CitiesController : Controller
    {

        [HttpGet("/cities")]
        public ActionResult Index()
        {
            List<City> allCity = City.GetAllCity();
            return View(allCity);
        }
        [HttpGet("/cities/derek")]
        public ActionResult Search()
        {
          return View();
        }
        [HttpPost("/cities")]
        public ActionResult Derek()
        {

            List<City> allCity = City.GetSearchCity(Request.Form["cityInput"]);
            return View("Index", allCity);
        }
    }
}
