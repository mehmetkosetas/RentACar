using RentoFull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentoFull.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (var db = new RentoFull.Models.CarsDB())
            {
                // Veritabanından car makerları al
                var carMakes = db.Cars.Select(c => c.Maker).Distinct().ToList();

                // Enum değerlerini al (CType enum'ı)
                var carTypes = Enum.GetValues(typeof(RentoFull.Models.Type))
                    .Cast<RentoFull.Models.Type>()
                    .ToList();
                
                
                var carModelsByMake = db.Cars
            .GroupBy(c => c.Maker)
            .ToDictionary(
                g => g.Key,
                g => g.Select(c => new { c.Model, c.ID }).Distinct().ToList()
            );
                // Seçilenler için ViewData kullanarak veri göndereceğiz
                ViewData["CarMakes"] = carMakes;
                ViewData["CarTypes"] = carTypes;
                ViewData["CarModelsByMake"] = carModelsByMake; // CarModels'ı da ekliyoruz
                return View();
            }
        }
        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {


            return View();
        }
        public ActionResult Car_List()
        {
            using (var db = new RentoFull.Models.CarsDB())
            {
                var cars = db.Cars.ToList();
                if (cars == null || !cars.Any())
                {
                    return View(new List<RentoFull.Models.Car>());
                }
                return View(cars);
            }
        }

        public ActionResult Car_Info(int id)
        {
            using (var db = new RentoFull.Models.CarsDB())
            {
                var car = db.Cars.FirstOrDefault(c => c.ID == id); // We are choosing car from DB according to ID
                if (car == null)
                {
                    return HttpNotFound(); // If there is no car return error message
                }
                return View(car);
            }
        }


        public JsonResult GetCarModelsByMake(string make)
        {
            using (var db = new RentoFull.Models.CarsDB())
            {
                // Marka ismine göre araç modellerini al
                var carModels = db.Cars
                    .Where(c => c.Maker == make)  // Markaya göre filtreleme
                    .Select(c => new { c.ID, c.Model })  // ID ve Model bilgilerini al
                    .ToList();

                // JSON formatında geri dön
                return Json(carModels, JsonRequestBehavior.AllowGet);
            }
        }

    }

}