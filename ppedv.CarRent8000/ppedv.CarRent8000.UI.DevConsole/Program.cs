// See https://aka.ms/new-console-template for more information
using Autofac;
using ppedv.CarRent8000.Data.EfCore;
using ppedv.CarRent8000.Logic;
using ppedv.CarRent8000.Model.Contracts;
using ppedv.CarRent8000.Model.DomainModel;
using System.Reflection;
string conString = "Server=(localdb)\\mssqllocaldb;Database=CarRent8000_dev;Trusted_Connection=true;";

Console.WriteLine("Hello, World!");

//DI per Hand
//IRepository repo = new ppedv.CarRent8000.Data.EfCore.EfContextRepositoryAdapter(conString);


//DI per Reflection
//var path = @"C:\Users\rulan\source\repos\ppedvAG\Inhouse_Architektur_Special\ppedv.CarRent8000\ppedv.CarRent8000.Data.EfCore.Tests\bin\Debug\net6.0\ppedv.CarRent8000.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//IRepository repo = (IRepository)Activator.CreateInstance(typeMitRepo,conString);

//DI per AutoFac
var builder = new ContainerBuilder();
builder.Register(x => new EfContextRepositoryAdapter(conString)).AsImplementedInterfaces();
builder.RegisterType<RentService>().AsImplementedInterfaces();  
var container = builder.Build();





IRepository repo = container.Resolve<IRepository>();
IRentService rentService = container.Resolve<IRentService>();

foreach (var car in repo.GetAll<Car>())
{
    if (rentService.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddDays(1)))
        Console.Write("JA ");
    else
        Console.Write("NEIN ");

    Console.WriteLine($"{car.Manufacturer} {car.Model} {car.Color}");
}
