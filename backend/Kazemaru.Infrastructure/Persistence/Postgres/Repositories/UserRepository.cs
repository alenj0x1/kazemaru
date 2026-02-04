using Kazemaru.Domain.Entities;
using Kazemaru.Domain.Interfaces.Persistence.Postgres.Repositories;
using Kazemaru.Infrastructure.Persistence.Postgres.Context;

namespace Kazemaru.Infrastructure.Persistence.Postgres.Repositories;

public class UserRepository(KazemaruDbContext db) : BaseRepository<User>(db), IUserRepository
{
    private readonly KazemaruDbContext _db = db;

    public Guid? FindIfExists(Guid userId)
    {
        try
        {
            return _db.Users.Where(user => user.UserId == userId).Select(user => user.UserId).FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Guid? FindIfExists(string username)
    {
        try
        {
            return _db.Users.Where(user => user.Username == username).Select(user => user.UserId).FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public User? Get(string username)
    {
        try
        {
            return _db.Users.FirstOrDefault(user => user.Username == username);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public User? Get(Guid userId)
    {
        try
        {
            return _db.Users.FirstOrDefault(user => user.UserId == userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}