using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.CarRent8000.Model.Contracts;
using ppedv.CarRent8000.Model.DomainModel;

namespace ppedv.CarRent8000.UI.WebMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly IRepository repository;

        public CarsController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: CarsController
        public ActionResult Index()
        {
            var cars = repository.GetAll<Car>();
            return View(cars);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.GetById<Car>(id));
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View(new Car() { Color="Grün"});
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                repository.Add(car);
                repository.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.GetById<Car>(id));

        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                repository.Update(car);
                repository.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.GetById<Car>(id));

        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                repository.Delete(car);
                repository.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
