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
}