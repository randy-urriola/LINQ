LinqQueries queries = new LinqQueries();

// Toda la coleccion
ImprimirValores(queries.TodaLaColeccion());

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
//ImprimirValores(queries.TercerYCuartoLibroDeMasDe400Pag());

// El titulo y cantidad de páginas de los Tres primeros libros
Imprimir(queries.TresPrimerosLibros());

// Cantidad de libros con paginas entre 200 y 500
//Console.WriteLine("Cantidad de libros con paginas entre 200 y 500: {0}", queries.CantidadDeLibros());

// Menor fecha de publicacion
//Console.WriteLine($"Menor fecha de publicacion: {queries.MenorFechaPublicacion()}");

// Imprimir la mayor cantidad de páginas de todos los libros
//Console.WriteLine($"Mayor cantidad de paginas: {queries.MayorNumeroDePaginas()}");

// Imprimir el libro con menor número de páginas pero mayor a 0
// var libro = queries.LibroConMenorNumeroDePaginas();
// Console.WriteLine($"Libro con menor número de páginas: {libro.Title} - {libro.PageCount} paginas");

// Imprimir el libro con fecha de publicación más reciente
// var libroReciente = queries.LibroConFechaDePublicacionMasReciente();
// Console.WriteLine($"Libro con fecha de publicación más reciente: {libroReciente.Title} - {libroReciente.Publisheddate.ToShortDateString()}");

// Suma de pagina de 0 a 500
//Console.WriteLine($"Suma de todas las paginas de 0 a 500: {queries.SumaDeTodasLasPaginasDeEntre0Y500()}");

// Titulos de libros publicados despues del 2015
//Console.WriteLine($"Titulos de libros publicados despues del 2015: {queries.TitulosLibrosDespuesDel2015Concatenados()}");

// Promedio de caracteres de los titulos de libros
Console.WriteLine($"\nPromedio de caracteres de los titulos de libros: {queries.PromedioDeCaracteresTitulo()}");
Console.WriteLine($"Promedio de páginas: {queries.PromedioDePaginas()}");

void ImprimirValores(IEnumerable<Book> listadelibros)
{
  Console.WriteLine("\n{0, -60} {1, 9} {2, 15}\n", "Titulo", "N. Paginas", "Fecha pulicacion");
  foreach(var item in listadelibros)
  {
    Console.WriteLine("{0, -60} {1, 9} {2, 15}", item.Title, item.PageCount, item.Publisheddate.ToShortDateString());
  }
}

void Imprimir(IEnumerable<Item> listadelibros)
{
  Console.WriteLine("\n{0, -60} {1, 9}\n", "Titulo", "N. Paginas");
  foreach(var item in listadelibros)
  {
    Console.WriteLine("{0, -60} {1, 9}", item.Title, item.PageCount);
  }
}