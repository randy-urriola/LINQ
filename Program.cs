LinqQueries queries = new LinqQueries();

// Toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

// Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesDel2000());

// Libros con mas de 250 paginas y con titulo In Action
// ImprimirValores(queries.LibrosConMasDe250PagConTituloInAction());

// Todos los libros tienen status
// Console.WriteLine("Todos los libros tienen status: {0}", queries.TodosLosLibrosTienenStatus());

// Libros publicados en 2005
//Console.WriteLine("Algun libro publicado en 2005: {0}", queries.LibrosPublicadosEn2005());

// Libros que contienen Python
//ImprimirValores(queries.LibrosContienenPython());

// Libros ordenados por titulo
//ImprimirValores(queries.LibrosOrdenadosPorTitulo());

// Libros con mas de 450 paginas ordenados de forma descendente
//ImprimirValores(queries.LibrosConMasDe450PagOrdenadoDesc());

// Tres primeros libros ordenados por fecha
//ImprimirValores(queries.TresPrimerosLibrosOrdenadosPorFecha());

// Tercer y cuarto libro de mas de 400 paginas
ImprimirValores(queries.TercerYCuartoLibroDeMasDe400Pag());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
  Console.WriteLine("\n{0, -60} {1, 9} {2, 15}\n", "Titulo", "N. Paginas", "Fecha pulicacion");
  foreach(var item in listadelibros)
  {
    Console.WriteLine("{0, -60} {1, 9} {2, 15}", item.Title, item.PageCount, item.Publisheddate.ToShortDateString());
  }
}