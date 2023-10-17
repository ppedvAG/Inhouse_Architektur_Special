// See https://aka.ms/new-console-template for more information
using HalloSingelton;
using System;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        Parallel.For(0, 20, i => Logger.Instance.Info($" {i} Hallo welt"));

        Logger.Instance.Info("Hallo welt");
        Logger.Instance.Info("Hallo welt");
        Logger.Instance.Info("Hallo welt");
        Logger.Instance.Info("Hallo welt");
    }
}