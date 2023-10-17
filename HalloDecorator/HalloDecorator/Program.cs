// See https://aka.ms/new-console-template for more information
using HalloDecorator;

Console.WriteLine("Hello, World!");


var p1 = new Käse(new Käse(new Salami(new Brot())));


Console.WriteLine(p1.Name + "  " + p1.Price);