using Microsoft.EntityFrameworkCore;

public class UsersService
{
  private readonly DatabaseContext _context;

  public UsersService(DatabaseContext context)
  {
    this._context = context;
  }

  public IQueryable<User> List()
  {
    return _context.Users;
  }

  public int Create(User user)
  {
    _context.Users.Add(user);
    _context.SaveChanges();

    return user.Id;
  }
}