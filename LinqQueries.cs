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
}