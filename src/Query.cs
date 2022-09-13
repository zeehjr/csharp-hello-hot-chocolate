public class Query
{
  [UsePaging]
  [UseFiltering]
  [UseSorting]
  public IQueryable<User> GetPeople([Service] UsersService usersService)
  {
    return usersService.List();
  }
}
