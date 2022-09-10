using Microsoft.EntityFrameworkCore;

public class Book
{
  public string Title { get; set; }

  public Author Author { get; set; }
}

public class Author
{
  public string Name { get; set; }
}

public class PersonInput
{
  public string Name { get; set; }
  public int Age { get; set; }
}

public class Mutation
{
  public string AddItem(DatabaseContext context, PersonInput personInput)
  {
    var car = new Car { Model = "Monza" };
    // context.Cars.Add(car);
    var person = new Person { Name = personInput.Name, Age = personInput.Age, Car = car };
    context.People.Add(person);
    context.SaveChanges();

    return $"{personInput.Name} criado";
  }
}

public class Query
{
  public List<Person> GetPeople(DatabaseContext context)
  {
    return context.People
      .Where(p => p.Age > 2)
      .Include(p => p.Car)
      .ToList();
  }

  public Book GetPerson(DatabaseContext context)
  {
    // var items = from person in context.People
    //             where person.Age >= 50
    //             select person;

    var fallbackPerson = new Person { Name = "Aroldo", Age = 59 };

    var person = context
                  .People
                  .ToList()
                  .FirstOrDefault(fallbackPerson);

    return new Book
    {
      Title = person.Age.ToString(),
      Author = new Author
      {
        Name = person.Name,
      }
    };
  }

  public string GetPedro() => "pedro";

  public int GetAge() => 99;
}
