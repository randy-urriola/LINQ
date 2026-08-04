public class Book
{
  public string Title { get; set; } = "";
  public int PageCount { get; set; } = 0;
  public string Status { get; set; } = "";
  public DateTime Publisheddate { get; set; }

  public string[] Authors { get; set; } = new string[0];
  public string[] Categories { get; set; } = new string[0];
}