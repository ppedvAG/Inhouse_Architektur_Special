// See https://aka.ms/new-console-template for more information
using ppedv.CarRent8000.Logic;
using ppedv.CarRent8000.Model.Contracts;
using ppedv.CarRent8000.Model.DomainModel;
string conString = "Server=(localdb)\\mssqllocaldb;Database=CarRent8000_dev;Trusted_Connection=true;";

Console.WriteLine("Hello, World!");

IRepository repo = new ppedv.CarRent8000.Data.EfCore.EfContextRepositoryAdapter(conString);
var rentService = new RentService(repo);

foreach (var car in repo.GetAll<Car>())
{
    if (rentService.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddDays(1)))
        Console.Write("JA ");
    else
        Console.Write("NEIN ");

    Console.WriteLine($"{car.Manufacturer} {car.Model} {car.Color}");
}
