using System.Transactions;

public class LinqQueries
{
  private List<Book> librosCollection = new List<Book>();
  public LinqQueries()
  {
    using (StreamReader reader = new StreamReader("books.json"))
    {
      string json = reader.ReadToEnd();
      this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); // lo convierte el json a list book
    }
  }

  public IEnumerable<Book> TodaLaColeccion()
  {
    return librosCollection;
  }

  public IEnumerable<Book> LibrosDespuesDel2000()
  {
    // Extention method
    // return librosCollection.Where(x => x.Publisheddate.Year > 2000);

    // Query syntax
    return from libro in librosCollection
           where libro.Publisheddate.Year > 2000
           select libro;
  }

  public IEnumerable<Book> LibrosConMasDe250PagConTituloInAction()
  {
    // Extention method
    //return librosCollection.Where(x => x.PageCount > 250 && x.Title.Contains("in Action"));

    // Query syntax
    return from libro in librosCollection
           where libro.PageCount > 250 && libro.Title.Contains("in Action")
           select libro;
  }

  public bool TodosLosLibrosTienenStatus()
  {
    return librosCollection.All(x => x.Status != string.Empty);
  }

  public bool LibrosPublicadosEn2005()
  {
    return librosCollection.Any(x => x.Publisheddate.Year == 2005);
  }

  public IEnumerable<Book> LibrosContienenPython()
  {
    return librosCollection.Where(p => p.Categories.Contains("Python"));
  }

  public IEnumerable<Book> LibrosOrdenadosPorTitulo()
  {
    return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
  }

  public IEnumerable<Book> LibrosConMasDe450PagOrdenadoDesc()
  {
    return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
  }

  public IEnumerable<Book> TresPrimerosLibrosOrdenadosPorFecha()
  {
    return librosCollection
    .Where(p => p.Categories.Contains("Java"))
    .OrderByDescending(p => p.Publisheddate)
    .Take(3);
  }

  public IEnumerable<Book> TercerYCuartoLibroDeMasDe400Pag()
  {
    return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
  }

  public IEnumerable<Item> TresPrimerosLibros()
  {
    return librosCollection.Take(3).Select(p => new Item { Title = p.Title, PageCount = p.PageCount });
  }

  public int CantidadDeLibros()
  {
    return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
  }

  public DateTime MenorFechaPublicacion()
  {
    return librosCollection.Min(p => p.Publisheddate);
  }

  public int MayorNumeroDePaginas()
  {
    return librosCollection.Max(p => p.PageCount);
  }

  public Book LibroConMenorNumeroDePaginas()
  {
    return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
  }

  public Book LibroConFechaDePublicacionMasReciente()
  {
    return librosCollection.MaxBy(p => p.Publisheddate);
  }

  public int SumaDeTodasLasPaginasDeEntre0Y500()
  {
    return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
  }

  public string TitulosLibrosDespuesDel2015Concatenados()
  {
    return librosCollection
    .Where(p => p.Publisheddate.Year > 2015)
    .Aggregate("", (TitulosLibros, next) =>
    {
      if (TitulosLibros != string.Empty)
        TitulosLibros += " - " + next.Title;
      else
        TitulosLibros += next.Title;

      return TitulosLibros;
    });
  }

  public double PromedioDeCaracteresTitulo()
  {
    return librosCollection.Average(p => p.Title.Length);
  }

  public double PromedioDePaginas()
  {
    return librosCollection.Where(p => p.PageCount > 0).Average(p => p.PageCount);
  }

  public IEnumerable<IGrouping<int, Book>> LibrosAgrupadosPorAnio()
  {
    return librosCollection.Where(p => p.Publisheddate.Year >= 2000).GroupBy(g => g.Publisheddate.Year);
  }

  public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
  {
    return librosCollection.ToLookup(p => p.Title[0], p => p); // el primer caracter del titulo es la llave y el libro es el valor
  }

  public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Pag()
  {
    var librosDespuesDel2005 = librosCollection.Where(p => p.Publisheddate.Year > 2005);
    var librosConMasDe500Pag = librosCollection.Where(p => p.PageCount > 500);
    
    return librosDespuesDel2005.Join(librosConMasDe500Pag, p=> p.Title, x => x.Title, (p, x) => p);
  }
}