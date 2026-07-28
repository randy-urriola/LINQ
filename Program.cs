LinqQueries queries = new LinqQueries();

ImprimirValores(queries.TodaLaColeccion());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
  Console.WriteLine("\n{0, -60} {1, 9} {2, 15}\n", "Titulo", "N. Paginas", "Fecha pulicacion");
  foreach(var item in listadelibros)
  {
    Console.WriteLine("{0, -60} {1, 9} {2, 15}", item.Title, item.PageCount, item.Publisheddate.ToShortDateString());
  }
}