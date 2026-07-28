using System;

class Program
{
  static void Main(string[] args)
  {
    string[] frutas = ["Sandia", "Fresa", "Mango", "Mango de azucar", "Mango tommy"];
    var esMango = frutas.Where(f => f.StartsWith("Mango")).ToList();
    esMango.ForEach(m => Console.WriteLine(m));
  }
}