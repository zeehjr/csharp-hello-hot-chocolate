using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

  public DbSet<Person> People { get; set; }
  public DbSet<Car> Cars { get; set; }
}

public class Person
{
  [Key]
  public int ID { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public int CarId { get; set; }
  public Car Car { get; set; }
}

public class Car
{
  [Key]
  public int ID { get; set; }

  public string Model { get; set; }
}