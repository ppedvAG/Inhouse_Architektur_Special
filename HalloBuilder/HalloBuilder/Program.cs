// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");


var s1 = new Schrank.Builder()
                    .SetBöden(4)
                    .SetTüren(5)
                    .SetFarbe("gelb")
                    .Create();

var s2 = new Schrank.Builder()
                    .SetBöden(2)
                    .SetTüren(4)
                    .SetOberfläche(Oberfläche.Gewachst)
                    .Create();