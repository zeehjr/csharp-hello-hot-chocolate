public class UserInput
{
  public string Name { get; set; }
}

public class Mutation
{
  public string AddItem([Service] UsersService usersService, UserInput userInput)
  {
    var post = new Post { Text = "Hello, how are you today?" };

    var user = new User { Name = userInput.Name, Posts = new List<Post> { post } };

    var id = usersService.Create(user);

    return $"'{user.Name}' created with id {id}.";
  }
}