using System.ComponentModel.DataAnnotations;

public class Post
{
  [Key]
  public int Id { get; set; }

  public string Text { get; set; }
}